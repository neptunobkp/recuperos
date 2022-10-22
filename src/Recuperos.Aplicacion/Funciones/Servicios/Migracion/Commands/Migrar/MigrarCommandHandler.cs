using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Comun.Helpers;
using Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Utiles;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Servicios.Migracion.Commands.Migrar
{
    public class MigrarCommandHandler : IRequestHandler<MigrarCommand, ResultadoMigracion>, IRequestHandler<UtilesMigraSiniestroCommand, ResultadoMigracion>
    {
        private readonly IGenerateDbContext _context;
        private readonly IApiMigracion _migrador;
        public MigrarCommandHandler( IGenerateDbContext context, IApiMigracion migrador)
        {
            _context = context;
            _migrador = migrador;
        }

        public async Task<ResultadoMigracion> Handle(UtilesMigraSiniestroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var resultado = new ResultadoMigracion();
                switch (request.Tipo)
                {
                    case TiposProcesosUtiles.PorRango:
                        foreach (var cadaFecha in DateComoNumberHelper.ListarRango(request.Desde.Value, request.Hasta.Value))
                            await HandleImportacionPorFecha(cancellationToken, cadaFecha, resultado, db);
                        break;
                    case TiposProcesosUtiles.PorDia:
                        await HandleImportacionPorFecha(cancellationToken, request.DiaEspecifico.Value, resultado, db);
                        break;
                    case TiposProcesosUtiles.PorNumeros:
                        foreach (var cadaNumero in request.Numeros)
                            await HandleImportacionPorNumero(cancellationToken, request.Compania, cadaNumero, resultado, db);
                        break;
                    case TiposProcesosUtiles.PorNumero:
                        await HandleImportacionPorNumero(cancellationToken, request.Compania, request.Numero, resultado, db);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(request));
                }

                return resultado;
            }
        }

        public async Task<ResultadoMigracion> Handle(MigrarCommand request, CancellationToken cancellationToken)
        {
            var resultado = new ResultadoMigracion();
            using (var db = _context.GenerateNewContext())
            {
                for (var i = request.Desde; i <= request.Hasta; i = i.AddDays(1))
                {
                    await HandleImportacionPorFecha(cancellationToken, i, resultado, db);
                }
            }
            return resultado;
        }

        public async Task HandleImportacionPorNumero(CancellationToken cancellationToken, TiposCompania compania, int numero, ResultadoMigracion resultado, IAppDbContext db)
        {
            var siniestrosImportables = await _migrador.GetSiniestro(numero, compania);
            if (siniestrosImportables != null)
            {
                try
                {
                    if (!db.Siniestros.Any(t => t.Numero == siniestrosImportables.Numero))
                    {
                        await HandleImportacion(cancellationToken, siniestrosImportables, db);
                        resultado.Cargados++;
                    }
                }
                catch (Exception ex)
                {
                    resultado.Fallos.Add(siniestrosImportables.Numero, ex.Message);
                }
            }
        }

        public async Task HandleImportacionPorFecha(CancellationToken cancellationToken, DateTime fecha,
            ResultadoMigracion resultado, IAppDbContext db)
        {
            var siniestrosImportables = await _migrador.GetSeedSiniestros(fecha);
            resultado.Total = resultado.Total + siniestrosImportables.Count;

            foreach (var cadaSiniestroImportable in siniestrosImportables)
            {
                try
                {
                    if (db.Siniestros.Any(t => t.Numero == cadaSiniestroImportable.Numero)) continue;
                    await HandleImportacion(cancellationToken, cadaSiniestroImportable, db);
                    resultado.Cargados++;
                }
                catch (Exception ex)
                {
                    resultado.Fallos.Add(cadaSiniestroImportable.Numero, ex.Message);
                }
            }
        }

        private async Task HandleImportacion(CancellationToken cancellationToken, Siniestro cadaSiniestroImportable, IAppDbContext db)
        {
            IniciarConstruccionSiniestro(cadaSiniestroImportable);
            await ImportarEstado(cadaSiniestroImportable, db);
            db.Siniestros.Add(cadaSiniestroImportable);
            await db.SaveChangesAsync(cancellationToken);
            await ImportarDimensiones(cancellationToken, cadaSiniestroImportable, db);
        }

        private async Task ImportarDimensiones(CancellationToken cancellationToken, Siniestro cadaSiniestroImportable,
            IAppDbContext db)
        {
            await ImportarObservaciones(cadaSiniestroImportable, db);
            await ImportarBitacora(cadaSiniestroImportable, db);
            await ImportarTerceros(cadaSiniestroImportable, db);
            await db.SaveChangesAsync(cancellationToken);
        }


        private async Task ImportarTerceros(Siniestro cadaSiniestroImportable, IAppDbContext db)
        {
            var observaciones = await _migrador.GetTerceros(cadaSiniestroImportable.Numero);
            foreach (var cadaObservacionImportada in observaciones)
            {
                var nuevoTercero = new Tercero();
                nuevoTercero.SiniestroId = cadaSiniestroImportable.Id;
                nuevoTercero.Rut = Comun.Helpers.RutHelper.ExtraerRutDeRutFormateadoSinDv(cadaObservacionImportada.Rut);
                nuevoTercero.Nombres = cadaObservacionImportada.Nombres;
                nuevoTercero.Direccion = cadaObservacionImportada.Direccion;
                nuevoTercero.Telefono = cadaObservacionImportada.Telefono;
                nuevoTercero.Correo = cadaObservacionImportada.Correo;
                nuevoTercero.TelefonoAlt = cadaObservacionImportada.Telefonoalt;

                var vehiculoImportado = await _migrador.GetVehiculo(cadaSiniestroImportable.Numero,
                    (int)cadaObservacionImportada.Id.Value);

                if (vehiculoImportado != null)
                {
                    nuevoTercero.Vehiculo = new TerceroVehiculo();
                    nuevoTercero.Vehiculo.Marca = vehiculoImportado.Marca;
                    nuevoTercero.Vehiculo.Modelo = vehiculoImportado.Modelo;
                    nuevoTercero.Vehiculo.Patente = vehiculoImportado.Patente;
                    nuevoTercero.Vehiculo.NumeroMotor = vehiculoImportado.Numeromotor;
                    nuevoTercero.Vehiculo.NumeroChasis = vehiculoImportado.Numerochasis;
                    nuevoTercero.Vehiculo.Color = vehiculoImportado.Color;
                }
                db.Terceros.Add(nuevoTercero);
            }
        }


        private async Task ImportarBitacora(Siniestro cadaSiniestroImportable, IAppDbContext db)
        {
            var observaciones = await _migrador.GetBitacora(cadaSiniestroImportable.Numero);
            foreach (var cadaObservacionImportada in observaciones)
            {
                var nuevaObservacion = new EntradaBitacora();
                nuevaObservacion.SiniestroId = cadaSiniestroImportable.Id;
                if (cadaObservacionImportada.Usuarioid.HasValue)
                {
                    var ejecutivoRut = ((int)cadaObservacionImportada.Usuarioid.Value).ToString();
                    if (db.Usuarios.Any(t => t.Rut == ejecutivoRut))
                    {
                        var usuario = db.Usuarios.First(t => t.Rut == ejecutivoRut);
                        nuevaObservacion.UsuarioId = usuario.Id;
                    }
                    else
                    {
                        var usuarioFijo = db.Usuarios.First(t => t.Rut == "12851962");
                        nuevaObservacion.UsuarioId = usuarioFijo.Id;
                    }
                }

                nuevaObservacion.Fecha =
                    cadaObservacionImportada.Fecha.HasValue ? cadaObservacionImportada.Fecha.Value : DateTime.Now;
                nuevaObservacion.Hora = cadaObservacionImportada.Hora;
                nuevaObservacion.Detalle = cadaObservacionImportada.Detalle?.Trim();
                nuevaObservacion.TipoBitacoraId = 1;
                db.EntradasBitacoras.Add(nuevaObservacion);
            }
        }

        private async Task ImportarObservaciones(Siniestro cadaSiniestroImportable, IAppDbContext db)
        {
            var observaciones = await _migrador.GetObservaciones(cadaSiniestroImportable.Numero);
            foreach (var cadaObservacionImportada in observaciones)
            {
                var nuevaObservacion = new EntradaObservacion();
                nuevaObservacion.SiniestroId = cadaSiniestroImportable.Id;
                if (cadaObservacionImportada.Usuarioid.HasValue)
                {
                    var ejecutivoRut = ((int)cadaObservacionImportada.Usuarioid.Value).ToString();
                    if (db.Usuarios.Any(t => t.Rut == ejecutivoRut))
                    {
                        var usuario = db.Usuarios.First(t => t.Rut == ejecutivoRut);
                        nuevaObservacion.UsuarioId = usuario.Id;
                    }
                    else
                    {
                        var usuarioFijo = db.Usuarios.First(t => t.Rut == "12851962");
                        nuevaObservacion.UsuarioId = usuarioFijo.Id;
                    }
                }

                nuevaObservacion.Fecha =
                    cadaObservacionImportada.Fecha.HasValue ? cadaObservacionImportada.Fecha.Value : DateTime.Now;
                nuevaObservacion.Hora = cadaObservacionImportada.Hora;
                nuevaObservacion.Detalle = cadaObservacionImportada.Detalle?.Trim();
                nuevaObservacion.TipoObservacionId = 1;
                db.EntradasObservaciones.Add(nuevaObservacion);
            }
        }

        private async Task ImportarEstado(Siniestro cadaSiniestroImportable, IAppDbContext db)
        {
            int parser;
            var estadoImportado = await _migrador.GetEstado(cadaSiniestroImportable.Numero);

            if (estadoImportado.EjecutivoId.HasValue)
            {
                var ejecutivoRut = ((int)estadoImportado.EjecutivoId.Value).ToString();
                if (db.Usuarios.Any(t => t.Rut == ejecutivoRut))
                {
                    var usuario = db.Usuarios.First(t => t.Rut == ejecutivoRut);
                    cadaSiniestroImportable.EjecutivoId = usuario?.Id;
                }
            }

            cadaSiniestroImportable.EstadoId = (int?)estadoImportado.Estadoid;
            if (estadoImportado.Probabilidad.HasValue)
                cadaSiniestroImportable.Probabilidad = (int)estadoImportado.Probabilidad.Value;
            if (estadoImportado.FechaAsignacion.HasValue)
                cadaSiniestroImportable.FechaAsignacion = estadoImportado.FechaAsignacion.Value.Date;
            if (estadoImportado.Fecharecupero.HasValue)
                cadaSiniestroImportable.FechaRecupero = estadoImportado.Fecharecupero.Value;

            cadaSiniestroImportable.Daterc = estadoImportado.Daterc;
            cadaSiniestroImportable.CompaniaTercero = estadoImportado.CompaniaTercero;

            cadaSiniestroImportable.NumeroTercero =
                int.TryParse(estadoImportado.Numerotercero, out parser) ? parser : (int?)null;
            cadaSiniestroImportable.FechaCarta = Parsear(estadoImportado.FechaCarta);
            cadaSiniestroImportable.FechaPromesa = Parsear(estadoImportado.FechaPromesa);
            cadaSiniestroImportable.MontoSolicitado =
                int.TryParse(estadoImportado.MontoSolicitado, out parser) ? parser : (int?)null;
            cadaSiniestroImportable.Monto = int.TryParse(estadoImportado.Monto, out parser) ? parser : (int?)null;
            cadaSiniestroImportable.Telefono = estadoImportado.Telefono;
        }

        private static DateTime? Parsear(string fecha)
        {
            if (string.IsNullOrEmpty(fecha)) return null;
            var tokens = fecha.Contains("/") ? fecha.Split('/') : fecha.Split('-');
            return new DateTime(Convert.ToInt32(tokens.Last()), Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens.First()));
        }

        private static void IniciarConstruccionSiniestro(Siniestro cadaSiniestroImportable)
        {
            cadaSiniestroImportable.FechaUltimaActualizacion = DateTime.Now;
            cadaSiniestroImportable.FechaImportacion = DateTime.Now;
            cadaSiniestroImportable.FechaAsignacion = DateTime.Now.Date;
            cadaSiniestroImportable.FechaUltimoCambioEstado = DateTime.Now;
            cadaSiniestroImportable.FechaUltimoCambioEtapa = DateTime.Now;
            cadaSiniestroImportable.EstadoId = (int)TiposEstado.Analisis;
            cadaSiniestroImportable.Prescripcion = cadaSiniestroImportable.FechaSiniestro.Value.AddMonths(5).Date;
        }



    }
}