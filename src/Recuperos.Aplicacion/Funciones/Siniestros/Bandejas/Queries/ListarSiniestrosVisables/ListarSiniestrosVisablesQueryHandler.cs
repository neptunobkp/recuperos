using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Exportacion;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosVisables
{
    public class ListarSiniestrosVisablesQueryHandler : IRequestHandler<ListarSiniestrosVisablesQuery, SiniestroVisablesResponseViewModel>,
        IRequestHandler<ExportarSiniestrosVisablesQuery, byte[]>
    {
        private readonly IGenerateDbContext _db;
        private readonly IApiRecup02 _apiP02;
        private readonly IExportadorExcel _excel;
        private readonly IUsuarioActualService _usuarioActual;
        private readonly IMapper _mapper;
        public ListarSiniestrosVisablesQueryHandler(IGenerateDbContext db, IApiRecup02 equifax, IExportadorExcel excel, IMapper mapper, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _apiP02 = equifax;
            _excel = excel;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
        }

        public async Task<SiniestroVisablesResponseViewModel> Handle(ListarSiniestrosVisablesQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroVisablesViewModel>();
            using (var db = _db.GenerateNewContext())
            {

                if (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol))
                    request.Filtros.EjecutivoId = _usuarioActual.Id;

                var siniestros = ConsultarSiniestros(request, db);
                var cantidad = await siniestros.CountAsync(cancellationToken);
                var skiped = request.Pagina * request.ItemsPorPagina;

                var siniestrosResult = await siniestros
                    .Include("Estado")
                    .Include("Ejecutivo")
                    .Order(string.IsNullOrEmpty(request.Orden) ? "FechaDenuncio" : request.Orden, request.Direccion)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                foreach (var cadaResultado in siniestrosResult)
                {
                    await _apiP02.CompletarSiniestro(cadaResultado);
                    var vm = _mapper.Map<SiniestroVisablesViewModel>(cadaResultado);
                    vm.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    vm.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(vm);
                }

                return new SiniestroVisablesResponseViewModel()
                {
                    Items = resultado,
                    Total = cantidad
                };
            }
        }
        public async Task<byte[]> Handle(ExportarSiniestrosVisablesQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroVisablesExportableViewModel>();
            using (var db = _db.GenerateNewContext())
            {
                if (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol))
                    request.Filtros.EjecutivoId = _usuarioActual.Id;

                var siniestros = ConsultarSiniestros(request, db);
                var siniestrosResult = await siniestros
                    .Include("Estado")
                    .Include("Ejecutivo")
                    .OrderBy(t => t.EstadoId)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                foreach (var cadaResultado in siniestrosResult)
                {
                    await _apiP02.CompletarSiniestro(cadaResultado);
                    cadaResultado.Prescripcion = cadaResultado.FechaSiniestro.Value.AddMonths(5).Date;
                    var vm = _mapper.Map<SiniestroVisablesExportableViewModel>(cadaResultado);
                    vm.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    vm.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(vm);
                }
                return _excel.Exportar(resultado);
            }
        }
        private bool UsuarioEsRestringible(string rol)
        {
            return new List<string> { TiposRol.EstudioJuridicoExtern, TiposRol.CobroDirecto, TiposRol.PrejudicialInterno }.Any(t => t == rol);
        }

        private bool EsBandejaConPermisos(int requestEtapaId)
        {
            return requestEtapaId == (int)TiposEtapa.EsudiosJuridicos || requestEtapaId == (int)TiposEtapa.CobroDirecto || requestEtapaId == (int)TiposEtapa.PrejudicialInterno;
        }

       


        private static IQueryable<Siniestro> ConsultarSiniestros(IListarSiniestroVisablesQuery request, IAppDbContext db)
        {
            IQueryable<Siniestro> siniestros = db.Siniestros.Include(t => t.Estado)
                .Include(t => t.SolicitudesVisto.Select(p => p.EstadoTDestino))
                .Where(t => t.EstadoVisado != null && t.EstadoVisado.Value > 0);

            if (request.Filtros != null)
            {
                siniestros = FiltrarPorNumeroSiniestro(request, siniestros);
                siniestros = FiltrarPorEjecutivo(request, siniestros);
                siniestros = FiltrarPorNumeroSiniestroEnColumna(request, siniestros);
                siniestros = FiltrarPorCompania(request, siniestros);
                siniestros = FiltrarPorFechaDesde(request, siniestros);
                siniestros = FiltrarPorFechaHasta(request, siniestros);
                siniestros = FiltrarPorEstado(request, siniestros);
                siniestros = FiltrarPorProbabilidad(request, siniestros);
            }
            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorProbabilidad(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.Probabilidad.HasValue) return siniestros;
            var probabilidad = request.Filtros.Probabilidad.Value;
            siniestros = siniestros.Where(t => t.Probabilidad == probabilidad);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorEstado(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (request.Filtros.EstadoId.GetValueOrDefault() <= 0) return siniestros;
            var estadoId = request.Filtros.EstadoId.GetValueOrDefault();
            siniestros = siniestros.Where(t => t.EstadoId == estadoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorFechaHasta(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.FechaHasta.HasValue) return siniestros;
            var fechaNormalizada = request.Filtros.FechaHasta.Value.AddDays(1).Date;
            siniestros = siniestros.Where(t => t.FechaSiniestro < fechaNormalizada);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorFechaDesde(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.FechaDesde.HasValue) return siniestros;
            var fechaNormalizada = request.Filtros.FechaDesde.Value.Date;
            siniestros = siniestros.Where(t => t.FechaSiniestro >= fechaNormalizada);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorCompania(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (request.Filtros.Compania.HasValue)
            {
                siniestros = siniestros.Where(t => t.Compania == request.Filtros.Compania.Value);
            }

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestroEnColumna(IListarSiniestroVisablesQuery request,
            IQueryable<Siniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.InnerNumeroSiniestro)) return siniestros;
            var numeroSiniestro = Convert.ToInt32(request.Filtros.InnerNumeroSiniestro);
            siniestros = siniestros.Where(t => t.Numero == numeroSiniestro);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorEjecutivo(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoId.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoId.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestro(IListarSiniestroVisablesQuery request, IQueryable<Siniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.NumeroSiniestro)) return siniestros;
            var numeroSiniestro = Convert.ToInt32(request.Filtros.NumeroSiniestro);
            siniestros = siniestros.Where(t => t.Numero == numeroSiniestro);
            return siniestros;
        }
    }
}