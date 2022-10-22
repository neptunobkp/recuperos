using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Exportacion;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMonoUsuario
{
    public class ListarSiniestrosMonoUsuarioQueryHandler : IRequestHandler<ListarSiniestrosMonoUsuarioQuery, SiniestroMonoUsuarioResponseViewModel>,
        IRequestHandler<ExportarSiniestrosMonoUsuarioQuery, byte[]>
    {
        private readonly IGenerateDbContext _db;
        private readonly IApiRecup02 _apirecup02;
        private readonly IExportadorExcel _excel;
        private readonly IUsuarioActualService _usuarioActual;
        private readonly IMapper _mapper;

        public ListarSiniestrosMonoUsuarioQueryHandler(IGenerateDbContext db, IApiRecup02 apirecup02, IExportadorExcel excel, IMapper mapper, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _apirecup02 = apirecup02;
            _excel = excel;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
        }

        public async Task<SiniestroMonoUsuarioResponseViewModel> Handle(ListarSiniestrosMonoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroMonoUsuarioViewModel>();

            using (var db = _db.GenerateNewContext())
            {
                var ejecutivo = await db.Usuarios.AsNoTracking().SingleAsync(t => t.Id == _usuarioActual.Id, cancellationToken);

                if (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol))
                    request.Filtros.EjecutivoIdPermitible = _usuarioActual.Id;

                var siniestros = ConsultarSiniestros(request, db);

                var cantidad = await siniestros.CountAsync(cancellationToken);
                var cantidadTotal =
                    await ConsultarSiniestrosTotales(request, db).CountAsync(cancellationToken);

                var skiped = request.Pagina * request.ItemsPorPagina;

                var siniestrosResult = await siniestros
                    .Include("Estado")
                    .Include("Ejecutivo")
                    .OrderBy(t => t.EstadoId)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                foreach (var cadaResultado in siniestrosResult)
                {
                    await _apirecup02.CompletarSiniestro(cadaResultado);
                    var siniestroMonoMapped = _mapper.Map<SiniestroMonoUsuarioViewModel>(cadaResultado);
                    siniestroMonoMapped.Gestionable = EvaluarSiGestiona(cadaResultado, ejecutivo);
                    siniestroMonoMapped.Asignable = ejecutivo.Rol == TiposRol.Analista || ejecutivo.Rol == TiposRol.Supervisor;
                    siniestroMonoMapped.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    siniestroMonoMapped.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(siniestroMonoMapped);
                }

                return new SiniestroMonoUsuarioResponseViewModel()
                {
                    Items = resultado,
                    Total = cantidad,
                    TotalGlobal = cantidadTotal
                };
            }
        }

        public async Task<byte[]> Handle(ExportarSiniestrosMonoUsuarioQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroMonoUsuarioViewModel>();
            using (var db = _db.GenerateNewContext())
            {
                var siniestros = ConsultarSiniestros(request, db);
                var siniestrosResult = await siniestros
                    .Include("Estado")
                    .Include("Ejecutivo")
                    .OrderBy(t => t.EstadoId)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                foreach (var cadaResultado in siniestrosResult)
                {
                    await _apirecup02.CompletarSiniestro(cadaResultado);

                    cadaResultado.Prescripcion = cadaResultado.FechaSiniestro.GetValueOrDefault().AddMonths(5).Date;
                    var siniestroMonoMapped = _mapper.Map<SiniestroMonoUsuarioViewModel>(cadaResultado);
                    siniestroMonoMapped.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    siniestroMonoMapped.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(siniestroMonoMapped);
                }

                return _excel.Exportar(resultado);
            }
        }

        private bool UsuarioEsRestringible(string rol)
        {
            return new List<string> { TiposRol.EstudioJuridicoExtern, TiposRol.CobroDirecto, TiposRol.PrejudicialInterno, TiposRol.AdmPrejudicialInter }.Any(t => t == rol);
        }

        private bool EsBandejaConPermisos(int requestEtapaId)
        {
            return requestEtapaId == (int)TiposEtapa.EsudiosJuridicos || requestEtapaId == (int)TiposEtapa.CobroDirecto || requestEtapaId == (int)TiposEtapa.PrejudicialInterno;
        }

      

        private bool EvaluarSiGestiona(Siniestro cadaSiniestro, Usuario ejecutivo)
        {
            if (cadaSiniestro.EjecutivoId == ejecutivo.Id)
                return true;
            return ejecutivo.Rol == TiposRol.Analista || ejecutivo.Rol == TiposRol.Supervisor;
        }

        private static IQueryable<Siniestro> ConsultarSiniestrosTotales(IListarSiniestroQuery request, IAppDbContext db)
        {
            var siniestros = db.Siniestros.Where(t => t.Estado.EtapaId == request.EtapaId);

            if (request.Filtros.EjecutivoIdPermitible.HasValue)
            {
                var ejecutivoId = request.Filtros.EjecutivoIdPermitible.Value;
                siniestros = ejecutivoId == -1 ? siniestros.Where(t => t.EjecutivoId == null) : siniestros.Where(t => t.EjecutivoId == ejecutivoId);
            }

            return siniestros;
        }

        private static IQueryable<Siniestro> ConsultarSiniestros(IListarSiniestroQuery request, IAppDbContext db)
        {
            var siniestros = db.Siniestros.Include(t => t.Estado).Where(t => t.Estado.EtapaId == request.EtapaId);

            if (request.Filtros == null) return siniestros;

            siniestros = FiltrarPorNumeroSiniestro(request, siniestros);
            siniestros = FiltrarPorNumeroSiniestroEnColumna(request, siniestros);
            siniestros = FiltrarPorCompania(request, siniestros);
            siniestros = FiltrarPorFechaDesde(request, siniestros);
            siniestros = FiltrarPorFechaHasta(request, siniestros);
            siniestros = FiltrarPorEstado(request, siniestros);
            siniestros = FiltrarPorProbabilidad(request, siniestros);
            siniestros = FiltrarPorEjecutivoId(request, siniestros);
            siniestros = FiltrarPorEjecutivoPermitible(request, siniestros);
            siniestros = FiltrarPorRegion(request, siniestros);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorRegion(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.Region.HasValue) return siniestros;

            var regionid = request.Filtros.Region.Value;
            siniestros = siniestros.Where(t => t.Region == regionid);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorEjecutivoPermitible(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoIdPermitible.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoIdPermitible.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorEjecutivoId(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoId.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoId.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorProbabilidad(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.Probabilidad.HasValue) return siniestros;
            var probabilidad = request.Filtros.Probabilidad.Value;
            siniestros = siniestros.Where(t => t.Probabilidad == probabilidad);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorEstado(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (request.Filtros.EstadoId.GetValueOrDefault() <= 0) return siniestros;
            var estadoId = request.Filtros.EstadoId.Value;
            siniestros = siniestros.Where(t => t.EstadoId == estadoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorFechaHasta(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.FechaHasta.HasValue) return siniestros;
            var fechaNormalizada = request.Filtros.FechaHasta.Value.AddDays(1).Date;
            siniestros = siniestros.Where(t => t.FechaSiniestro < fechaNormalizada);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorFechaDesde(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.FechaDesde.HasValue) return siniestros;
            var fechaNormalizada = request.Filtros.FechaDesde.Value.Date;
            siniestros = siniestros.Where(t => t.FechaSiniestro >= fechaNormalizada);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorCompania(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.Compania.HasValue) return siniestros;
            siniestros = siniestros.Where(t => t.Compania == request.Filtros.Compania.Value);
            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestroEnColumna(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.InnerNumeroSiniestro)) return siniestros;
            var numeroSiniestro = Convert.ToInt32(request.Filtros.InnerNumeroSiniestro);
            siniestros = siniestros.Where(t => t.Id == numeroSiniestro);
            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestro(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (request.Filtros.NumeroSiniestro.GetValueOrDefault() <= 0) return siniestros;
            siniestros = siniestros.Where(t => t.Numero == request.Filtros.NumeroSiniestro.Value);
            return siniestros;
        }
    }
}
