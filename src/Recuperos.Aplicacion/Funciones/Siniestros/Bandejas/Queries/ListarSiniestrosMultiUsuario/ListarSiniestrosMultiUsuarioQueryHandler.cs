using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Utiles;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Exportacion;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ListarSiniestrosMultiUsuario
{
    public class ListarSiniestrosMultiUsuarioQueryHandler : IRequestHandler<ListarSiniestrosMultiUsuarioQuery, SiniestroMultiUsuarioResponseViewModel>,
        IRequestHandler<ExportarSiniestrosMultiUsuarioQuery, byte[]>,
        IRequestHandler<UtilesSiniestroCommand>
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger(typeof(ListarSiniestrosMultiUsuarioQueryHandler));
        private readonly IGenerateDbContext _db;
        private readonly IApiRecup02 _apiP02;
        private readonly IExportadorExcel _excel;
        private readonly IUsuarioActualService _usuarioActual;
        private readonly IMapper _mapper;

        public ListarSiniestrosMultiUsuarioQueryHandler(IGenerateDbContext db, IApiRecup02 equifax, IExportadorExcel excel, IMapper mapper, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _apiP02 = equifax;
            _excel = excel;
            _mapper = mapper;
            _usuarioActual = usuarioActual;
        }

        public async Task<SiniestroMultiUsuarioResponseViewModel> Handle(ListarSiniestrosMultiUsuarioQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroMultiUsuarioViewModel>();
            using (var db = _db.GenerateNewContext())
            {
                Collect("init");
                await SincronizarDiaADia(request, db, cancellationToken);


                Collect("Sincronizado");

                if (!BypassReglaPermisoRolBandeja(_usuarioActual.Rol, request.EtapaId) && (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol)))
                    request.Filtros.EjecutivoIdPermitible = _usuarioActual.Id;

                var siniestros = ConsultarSiniestros(request, db);
                var cantidad = await siniestros.CountAsync(cancellationToken);
                var totalGlobal = await ConsultarTotalSiniestros(request, db).CountAsync(cancellationToken);

                var skiped = request.Pagina * request.ItemsPorPagina;

                var siniestrosResult = await siniestros
                    .Include("Estado")
                    .Include("Ejecutivo")
                    .Order(string.IsNullOrEmpty(request.Orden) ? "FechaDenuncio" : request.Orden, request.Direccion)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                Collect("Consultado");
                foreach (var cadaResultado in siniestrosResult)
                {
                    await _apiP02.CompletarSiniestro(cadaResultado);
                    var vm = _mapper.Map<SiniestroMultiUsuarioViewModel>(cadaResultado);
                    vm.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    vm.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(vm);
                    Collect($"Completado {cadaResultado.Numero}");
                }

                _logger.Info(Trace());

                return new SiniestroMultiUsuarioResponseViewModel
                {
                    Items = resultado,
                    Total = cantidad,
                    TotalGlobal = totalGlobal
                };
            }
        }

        public async Task<byte[]> Handle(ExportarSiniestrosMultiUsuarioQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<SiniestroMultiUsuarioExportableViewModel>();
            using (var db = _db.GenerateNewContext())
            {
                if (EsBandejaConPermisos(request.EtapaId) && UsuarioEsRestringible(_usuarioActual.Rol))
                    request.Filtros.EjecutivoIdPermitible = _usuarioActual.Id;

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
                    var vm = _mapper.Map<SiniestroMultiUsuarioExportableViewModel>(cadaResultado);
                    vm.Alertado = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta;
                    vm.DiasAlerta = (DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays > cadaResultado.Estado.DiasAlerta
                        ? (int?)(DateTime.Now - cadaResultado.FechaAsignacion.GetValueOrDefault(DateTime.Now.Date)).TotalDays - cadaResultado.Estado.DiasAlerta
                        : (int?)null;
                    resultado.Add(vm);
                }
                return _excel.Exportar(resultado);
            }
        }

        public async Task<Unit> Handle(UtilesSiniestroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                switch (request.Tipo)
                {
                    case TiposProcesosUtiles.PorRango:
                        foreach (var cadaFecha in DateComoNumberHelper.ListarRango(request.Desde.Value, request.Hasta.Value))
                            await Sincronizar(db, cancellationToken, cadaFecha);
                        break;
                    case TiposProcesosUtiles.PorDia:
                        await Sincronizar(db, cancellationToken, request.DiaEspecifico.Value);
                        break;
                    case TiposProcesosUtiles.PorNumeros:
                        foreach (var cadaNumero in request.Numeros)
                            await Sincronizar(db, cancellationToken, cadaNumero, request.Compania);
                        break;
                    case TiposProcesosUtiles.PorNumero:
                        await Sincronizar(db, cancellationToken, request.Numero, request.Compania);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(request));
                }

                return Unit.Value;
            }
        }

        public List<String> Entradas { get; set; }
        public void Collect(string msj)
        {
            if (Entradas == null) Entradas = new List<string>();
            Entradas.Add($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.Millisecond}  {msj}");
        }

        public string Trace()
        {
            return string.Join(", ", Entradas);
        }

        private bool BypassReglaPermisoRolBandeja(string rol, int requestEtapaId) => rol == TiposRol.PrejudicialInterno && requestEtapaId == (int) TiposEtapa.EsudiosJuridicos;

        private bool UsuarioEsRestringible(string rol) =>
            new List<string> {
                    TiposRol.EstudioJuridicoExtern,
                    TiposRol.CobroDirecto,
                    TiposRol.PrejudicialInterno,
                    TiposRol.AdmPrejudicialInter }
                .Any(t => t == rol);

        private bool EsBandejaConPermisos(int requestEtapaId)
        {
            return requestEtapaId == (int)TiposEtapa.EsudiosJuridicos || requestEtapaId == (int)TiposEtapa.CobroDirecto || requestEtapaId == (int)TiposEtapa.PrejudicialInterno;
        }

        
        private async Task SincronizarDiaADia(ListarSiniestrosMultiUsuarioQuery request, IAppDbContext db, CancellationToken cancellationToken)
        {
            if (request.EtapaId == (int)TiposEtapa.Analisis)
            {
                var ultimaSincro = await db.Sincros.MaxAsync(t => t.Id, cancellationToken);
                _logger.Info($"ultima sincro {ultimaSincro.ToString()}");

                var configuracionSincronizacion = DateComoNumberHelper.EvaluarSiSincronizar(ultimaSincro);

                if (configuracionSincronizacion.PendientesSincronizacion != null && configuracionSincronizacion.PendientesSincronizacion?.Count > 0)
                {
                    db.Sincros.Add(new Sincro { Id = DateComoNumberHelper.Hoy() });
                    await db.SaveChangesAsync(cancellationToken);
                }

                if (configuracionSincronizacion.PendientesSincronizacion != null)
                    foreach (var cadaFecha in configuracionSincronizacion.PendientesSincronizacion)
                        await Sincronizar(db, cancellationToken, cadaFecha);

                await Sincronizar(db, cancellationToken, DateTime.Now);
            }
        }

        private async Task Sincronizar(IAppDbContext db, CancellationToken cancellationToken, DateTime fecha)
        {
            _logger.Info($"init sincro {fecha}");
            var siniestrosImportables = await _apiP02.GetSiniestros(fecha);
            _logger.Info($"sincos {fecha}: {string.Join(" ", siniestrosImportables.Select(t => t.Numero).ToArray())}");
            foreach (var cadaSiniestroImportable in siniestrosImportables)
            {
                if (!db.Siniestros.Any(t => t.Numero == cadaSiniestroImportable.Numero && t.Compania == cadaSiniestroImportable.Compania))
                {
                    _logger.Info($"sincro crear siniestro {cadaSiniestroImportable.Numero}");
                    cadaSiniestroImportable.FechaUltimoCambioEtapa = DateTime.Now;
                    cadaSiniestroImportable.FechaUltimoCambioEstado = DateTime.Now;
                    cadaSiniestroImportable.FechaUltimaActualizacion = DateTime.Now;
                    cadaSiniestroImportable.FechaImportacion = DateTime.Now;
                    cadaSiniestroImportable.Prescripcion = cadaSiniestroImportable.FechaSiniestro.Value.AddMonths(5).Date;

                    db.Siniestros.Add(cadaSiniestroImportable);
                    await db.SaveChangesAsync(cancellationToken);
                }
            }
        }

        private async Task Sincronizar(IAppDbContext db, CancellationToken cancellationToken, int numero, TiposCompania compania)
        {
            _logger.Info($"init sincro {numero}");
            var siniestrosImportables = await _apiP02.GetSiniestros(numero, compania);
            foreach (var cadaSiniestroImportable in siniestrosImportables)
            {
                if (!db.Siniestros.Any(t => t.Numero == cadaSiniestroImportable.Numero && t.Compania == cadaSiniestroImportable.Compania))
                {
                    _logger.Info($"sincro crear siniestro {cadaSiniestroImportable.Numero}");
                    cadaSiniestroImportable.FechaUltimoCambioEtapa = DateTime.Now;
                    cadaSiniestroImportable.FechaUltimoCambioEstado = DateTime.Now;
                    cadaSiniestroImportable.FechaUltimaActualizacion = DateTime.Now;
                    cadaSiniestroImportable.FechaImportacion = DateTime.Now;
                    cadaSiniestroImportable.Prescripcion = cadaSiniestroImportable.FechaSiniestro.GetValueOrDefault().AddMonths(5).Date;

                    db.Siniestros.Add(cadaSiniestroImportable);
                    await db.SaveChangesAsync(cancellationToken);
                }
            }
        }


        private static IQueryable<Siniestro> ConsultarTotalSiniestros(IListarSiniestroQuery request, IAppDbContext db)
        {
            IQueryable<Siniestro> siniestros = request.EtapaId == -1 ? db.Siniestros.Where(t => true) : db.Siniestros.Where(t => t.Estado.EtapaId == request.EtapaId);

            if (request.Filtros.EjecutivoIdPermitible.HasValue)
            {
                var ejecutivoId = request.Filtros.EjecutivoIdPermitible.Value;
                siniestros = ejecutivoId == -1 ? siniestros.Where(t => t.EjecutivoId == null) : siniestros.Where(t => t.EjecutivoId == ejecutivoId);
            }

            return siniestros;
        }

        private static IQueryable<Siniestro> ConsultarSiniestros(IListarSiniestroQuery request, IAppDbContext db)
        {
            IQueryable<Siniestro> siniestros;
            if (request.EtapaId == -1)
                siniestros = request.Filtros.TieneAlgunFiltro
                    ? db.Siniestros.Include(t => t.Estado)
                        .Include(t => t.SolicitudesVisto.Select(p => p.EstadoTDestino))
                    : db.Siniestros.Where(t => false);
            else
                siniestros = db.Siniestros.Include(t => t.Estado)
                    .Include(t => t.SolicitudesVisto.Select(p => p.EstadoTDestino))
                    .Where(t => t.Estado.EtapaId == request.EtapaId);

            if (request.Filtros != null)
            {
                siniestros = FiltrarPorOtraCompania(request, siniestros);
                siniestros = FiltrarPorNumeroSiniestro(request, siniestros);
                siniestros = FiltrarPorEjecutivo(request, siniestros);
                siniestros = FiltrarPorEjecutivoPermitible(request, siniestros);
                siniestros = FiltrarPorNumeroSiniestroEnColumna(request, siniestros);
                siniestros = FiltrarPorCompania(request, siniestros);
                siniestros = FiltrarPorFechaDesde(request, siniestros);
                siniestros = FiltrarPorFechaHasta(request, siniestros);
                siniestros = FiltrarPorEstado(request, siniestros);
                siniestros = FIltrarPorProbabilidad(request, siniestros);
            }
            return siniestros;
        }

        private static IQueryable<Siniestro> FIltrarPorProbabilidad(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
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
            if (request.Filtros.Compania.HasValue)
            {
                siniestros = siniestros.Where(t => t.Compania == request.Filtros.Compania.Value);
            }

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestroEnColumna(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.InnerNumeroSiniestro)) return siniestros;
            var numeroSiniestro = Convert.ToInt32(request.Filtros.InnerNumeroSiniestro);
            siniestros = siniestros.Where(t => t.Numero == numeroSiniestro);

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

        private static IQueryable<Siniestro> FiltrarPorEjecutivo(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (!request.Filtros.EjecutivoId.HasValue) return siniestros;
            var ejecutivoId = request.Filtros.EjecutivoId.Value;
            siniestros = ejecutivoId == -1
                ? siniestros.Where(t => t.EjecutivoId == null)
                : siniestros.Where(t => t.EjecutivoId == ejecutivoId);

            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorNumeroSiniestro(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (request.Filtros.NumeroSiniestro.GetValueOrDefault() <= 0) return siniestros;
            siniestros = siniestros.Where(t => t.Numero == request.Filtros.NumeroSiniestro.Value);
            return siniestros;
        }

        private static IQueryable<Siniestro> FiltrarPorOtraCompania(IListarSiniestroQuery request, IQueryable<Siniestro> siniestros)
        {
            if (string.IsNullOrEmpty(request.Filtros.OtraCompania)) return siniestros;

            if (request.Filtros.OtraCompania == "SINCOMPANIA")
                siniestros = siniestros.Where(t => t.CompaniaTercero == null || t.CompaniaTercero == "");
            else
                siniestros = siniestros.Where(t => t.CompaniaTercero == request.Filtros.OtraCompania);

            return siniestros;
        }

        
    }
}