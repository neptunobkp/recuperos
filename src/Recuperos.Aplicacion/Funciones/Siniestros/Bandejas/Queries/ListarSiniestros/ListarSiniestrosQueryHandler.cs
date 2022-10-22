using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Modelo.Queries;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestros
{
    public class ListarSiniestrosQueryHandler : IRequestHandler<ListarSiniestrosQuery, FilasSiniestroViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUsuarioActualService _usuarioActual;
        public ListarSiniestrosQueryHandler(IGenerateDbContext db, IMapper mapper, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
        }

        public async Task<FilasSiniestroViewModel> Handle(ListarSiniestrosQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<FilaSiniestroViewModel>();
            using (var db = _db.GenerateNewContext())
            {
                if (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol))
                    request.Filtros.EjecutivoIdPermitible = _usuarioActual.Id;

                var siniestros = Query(request, db);
                var cantidad = await siniestros.AsNoTracking().CountAsync(cancellationToken);
                var totalGlobal = await ConsultarTotalSiniestros(request, db).CountAsync(cancellationToken);

                var siniestrosResult = await siniestros
                    .Order(string.IsNullOrEmpty(request.Orden) ? "FechaDenuncio" : request.Orden, request.Direccion)
                    .Skip(request.Pagina * request.ItemsPorPagina)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);


                foreach (var cadaResultado in siniestrosResult)
                {
                    var vm = _mapper.Map<FilaSiniestroViewModel>(cadaResultado);
                    vm.Gestionable = _usuarioActual.Rol == TiposRol.Analista ||
                                     _usuarioActual.Rol == TiposRol.Supervisor ||
                                     cadaResultado.EjecutivoId == _usuarioActual.Id;
                    vm.Asignable = _usuarioActual.Rol == TiposRol.Analista || _usuarioActual.Rol == TiposRol.Supervisor;
                    resultado.Add(vm);
                }

                return new FilasSiniestroViewModel()
                {
                    Items = resultado,
                    Total = cantidad,
                    TotalGlobal = totalGlobal
                };
            }
        }

        private static IQueryable<QSiniestro> ConsultarTotalSiniestros(ListarSiniestrosQuery request, IAppDbContext db)
        {

            IQueryable<QSiniestro> siniestros = request.EtapaId < 0 ?
                (request.EtapaId == -1 ? db.QSiniestros.Where(t => true) : db.QSiniestros.Where(t => t.EstadoVisado != null && t.EstadoVisado.Value > 0)) :
                db.QSiniestros.Where(t => t.EtapaId == request.EtapaId);

            if (request.Filtros.EjecutivoIdPermitible.HasValue)
            {
                var ejecutivoId = request.Filtros.EjecutivoIdPermitible.Value;
                siniestros = ejecutivoId == -1 ? siniestros.Where(t => t.EjecutivoId == null) : siniestros.Where(t => t.EjecutivoId == ejecutivoId);
            }

            return siniestros;
        }


        private bool UsuarioEsRestringible(string rol) => new List<string> { TiposRol.EstudioJuridicoExtern, TiposRol.CobroDirecto, TiposRol.PrejudicialInterno, TiposRol.AdmPrejudicialInter }.Any(t => t == rol);
        private bool EsBandejaConPermisos(int requestEtapaId) => requestEtapaId == (int)TiposEtapa.EsudiosJuridicos || requestEtapaId == (int)TiposEtapa.CobroDirecto || requestEtapaId == (int)TiposEtapa.PrejudicialInterno;

        private static IQueryable<QSiniestro> Query(ListarSiniestrosQuery request, IAppDbContext db)
        {
            var siniestros = EnsamblarQueryInicial(request, db);

            if (request.Filtros == null)
                return siniestros;

            siniestros = request.Filtros.EstadoId.GetValueOrDefault() <= 0 ? siniestros : siniestros.Where(t => t.EstadoId == request.Filtros.EstadoId.Value);
            siniestros = !request.Filtros.Compania.HasValue ? siniestros : siniestros.Where(t => t.Compania == request.Filtros.Compania.Value);
            siniestros = request.Filtros.NumeroSiniestro.GetValueOrDefault() <= 0 ? siniestros : siniestros.Where(t => t.Numero == request.Filtros.NumeroSiniestro.Value);

            siniestros = string.IsNullOrEmpty(request.Filtros.EjecutivoNombre) ? siniestros : siniestros.Where(t => t.ActualizadoPor == request.Filtros.EjecutivoNombre);

            siniestros = !request.Filtros.FechaDesde.HasValue ? siniestros : siniestros.Where(t => t.FechaSiniestro >= DbFunctions.TruncateTime(request.Filtros.FechaDesde.Value));
            siniestros = !request.Filtros.FechaHasta.HasValue ? siniestros : siniestros.Where(t => t.FechaSiniestro <= DbFunctions.TruncateTime(request.Filtros.FechaHasta.Value));

            siniestros = !request.Filtros.Probabilidad.HasValue ? siniestros : siniestros.Where(t => t.Probabilidad == request.Filtros.Probabilidad.Value);
            siniestros = FiltrarPorEjecutivoId(request, siniestros);
            siniestros = FiltrarPorEjecutivoPermitible(request, siniestros);
            siniestros = FiltrarPorOtraCompania(request, siniestros);
            siniestros = FiltrarPorRegion(request, siniestros);

            return siniestros;
        }

        private static IQueryable<QSiniestro> FiltrarPorRegion(ListarSiniestrosQuery request, IQueryable<QSiniestro> siniestros)
        {
            if (!request.Filtros.Region.HasValue) return siniestros;

            var regionid = request.Filtros.Region.Value;
            siniestros = siniestros.Where(t => t.Region == regionid);

            return siniestros;
        }
        private static IQueryable<QSiniestro> FiltrarPorOtraCompania(ListarSiniestrosQuery request, IQueryable<QSiniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.OtraCompania)) return siniestros;

            if (request.Filtros.OtraCompania == "SINCOMPANIA")
                siniestros = siniestros.Where(t => t.CompaniaTercero == null || t.CompaniaTercero == "");
            else
                siniestros = siniestros.Where(t => t.CompaniaTercero == request.Filtros.OtraCompania);

            return siniestros;
        }

        private static IQueryable<QSiniestro> FiltrarPorEjecutivoId(ListarSiniestrosQuery request, IQueryable<QSiniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoId.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoId.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }

        private static IQueryable<QSiniestro> FiltrarPorEjecutivoPermitible(ListarSiniestrosQuery request, IQueryable<QSiniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoIdPermitible.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoIdPermitible.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }


        private static IQueryable<QSiniestro> EnsamblarQueryInicial(ListarSiniestrosQuery request, IAppDbContext db)
        {
            if (FiltrarSinEtapa(request))
                return request.EtapaId == -1 ? QueryTodasLasEtapas(request, db) : QueryTodasLasEtapasVisables(request, db);

            return db.QSiniestros.Where(t => t.EtapaId == request.EtapaId);
        }

        private static IQueryable<QSiniestro> QueryTodasLasEtapas(ListarSiniestrosQuery request, IAppDbContext db) =>
            !request.Filtros.TieneAlgunFiltro ? db.QSiniestros.Where(t => false) : db.QSiniestros.Where(t => true);

        private static IQueryable<QSiniestro> QueryTodasLasEtapasVisables(ListarSiniestrosQuery request, IAppDbContext db) =>
            db.QSiniestros.Where(t => t.EstadoVisado != null && t.EstadoVisado.Value > 0);

        private static bool FiltrarSinEtapa(ListarSiniestrosQuery request) => request.EtapaId < 0;

    }
}