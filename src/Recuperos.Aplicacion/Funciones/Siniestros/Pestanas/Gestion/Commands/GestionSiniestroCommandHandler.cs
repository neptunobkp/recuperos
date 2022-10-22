using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands.CambiarEstadoCommand.Pipelines.PreCambioEstado;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Models;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Gestion.Commands
{
    public class GestionSiniestroCommandHandler : IRequestHandler<GestionSiniestroCommand, List<string>>
    {
        private readonly IGenerateDbContext _db;
        private readonly IUsuarioActualService _usuarioActual;
        private readonly IMediator _mediator;

        public GestionSiniestroCommandHandler(IGenerateDbContext db, IUsuarioActualService usuarioActual, IMediator mediator)
        {
            _mediator = mediator;
            _db = db;
            _usuarioActual = usuarioActual;
        }
        public async Task<List<string>> Handle(GestionSiniestroCommand request, CancellationToken cancellationToken)
        {
            var resultado = new List<string>();
            using (var db = _db.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.Include(t => t.Estado).SingleAsync(t => t.Id == request.Id, cancellationToken);

                if (request.EstadoId.Touched && request.EstadoId.Value != siniestro.EstadoId)
                {
                    var estadodDestino = await db.Estados.AsNoTracking().SingleAsync(t => t.Id == request.EstadoId.Value, cancellationToken);
                    var transicion = await db.Transiciones.AsNoTracking().FirstAsync(t => t.EstadoOrigenId == siniestro.EstadoId && t.EstadoDestinoId == request.EstadoId.Value, cancellationToken);

                    if (transicion.Aprobable.GetValueOrDefault())
                    {
                        var nuevaSolicitud = new SolicitudVisto
                        {
                            FechaSolicitud = DateTime.Now,
                            Pendiente = true,
                            SolicitanteId = _usuarioActual.Id,
                            EstadoTDestinoId = transicion.EstadoDestinoId,
                            EstadoTOrigenId = transicion.EstadoOrigenId,
                            SiniestroId = request.Id
                        };
                        db.SolicitudesVisto.Add(nuevaSolicitud);
                        await db.SaveChangesAsync(cancellationToken);

                        siniestro.EstadoVisado = nuevaSolicitud.Id;

                        var entradaAdded = db.EntradasBitacoras.Add(new EntradaBitacora(request.Id, _usuarioActual.Id, (int)TiposCambioEstado.CambioEstado, $"Solicita visado para cambio de estado {siniestro.Estado?.Nombre} a {estadodDestino?.Nombre}"));
                        siniestro.FechaUltimoCambioEstado = DateTime.Now;
                        resultado.Add(entradaAdded.Detalle);
                    }
                    else
                    {
                        var entradaAdded = db.EntradasBitacoras.Add(new EntradaBitacora(request.Id, _usuarioActual.Id, (int)TiposCambioEstado.CambioEstado, $"Cambio de estado {siniestro.Estado?.Nombre} a {estadodDestino?.Nombre}"));
                        await _mediator.Publish(new PreCambioEstadoSiniestro { Siniestro = siniestro, NuevoEstado = estadodDestino }, cancellationToken);
                        siniestro.FechaUltimoCambioEstado = DateTime.Now;
                        siniestro.FechaUltimaActualizacion = DateTime.Now;
                        siniestro.EstadoId = request.EstadoId.Value;
                        resultado.Add(entradaAdded.Detalle);
                    }
                }

                if (request.Probabilidad.Touched && request.Probabilidad.Value != siniestro.Probabilidad)
                {
                    var entradaAdded = db.EntradasBitacoras.Add(new EntradaBitacora(request.Id, _usuarioActual.Id, (int)TiposCambioEstado.CambioProbabilidad, $"Cambio de probabilidad {(TiposProbabilidad)siniestro.Probabilidad} a {(TiposProbabilidad)request.Probabilidad.Value.GetValueOrDefault()}"));
                    siniestro.Probabilidad = request.Probabilidad.Value.Value;
                    resultado.Add(entradaAdded.Detalle);
                }

                AplicarCambiosEnDatosDinamicos(request, resultado, siniestro, db);

                await db.SaveChangesAsync(cancellationToken);
                return resultado;
            }
        }

        private void AplicarCambiosEnDatosDinamicos(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            AplicarCambioCompaniaTercero(request, resultado, siniestro, db);
            AplicarCambioNumeroTercero(request, resultado, siniestro, db);
            AplicarCambioFechaPromesa(request, resultado, siniestro, db);
            AplicarCambioMonto(request, resultado, siniestro, db);
            AplicarCambioTelefono(request, resultado, siniestro, db);
            AplicarCambioFechaCarta(request, resultado, siniestro, db);
            AplicarCambioMontoSolicitado(request, resultado, siniestro, db);
            AplicarCambioEstudioAbogados(request, resultado, siniestro, db);
        }

        private void AplicarCambioEstudioAbogados(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro,
            IAppDbContext db)
        {
            int parser = 0;
            if (request.EstudioAbogados.Touched && int.TryParse(request.EstudioAbogados.Value, out parser) &&
                parser != siniestro.EjecutivoId)
            {
                siniestro.EjecutivoId = parser;
                var ejecutivoEstudio = db.Usuarios.Find(parser);
                siniestro.EstudioAbogados = ejecutivoEstudio?.Nombres;
                siniestro.ActualizadoPor = ejecutivoEstudio?.Nombres;

                db.EntradasBitacoras.Add(new EntradaBitacora(siniestro.Id, _usuarioActual.Id,
                    (int)TiposCambioEstado.CambioEstado, $"asignó el siniestro a {siniestro.EstudioAbogados}."));

                if (siniestro.EstadoId != (int)TiposEstado.EstudiosJuridicosEstudiosJuridicos)
                {
                    siniestro.FechaUltimaActualizacion = DateTime.Now;
                    siniestro.FechaUltimoCambioEstado = DateTime.Now;
                    siniestro.FechaUltimoCambioEtapa = DateTime.Now;
                    siniestro.EstadoId = (int)TiposEstado.EstudiosJuridicosEstudiosJuridicos;

                    var estadodDestino = db.Estados.AsNoTracking().Single(t => t.Id == siniestro.EstadoId);
                    db.EntradasBitacoras.Add(new EntradaBitacora(siniestro.Id, _usuarioActual.Id,
                        (int)TiposCambioEstado.CambioEstado,
                        $"Cambio de estado {siniestro.Estado?.Nombre} a {estadodDestino?.Nombre}"));
                }
                RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "estudio jurídico");
            }
        }

        private void AplicarCambioMontoSolicitado(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.MontoSolicitado.Touched || request.MontoSolicitado.Value == siniestro.MontoSolicitado) return;
            RegistraMontoCambioBitacora(db, siniestro.Id, "monto solicitado", siniestro.MontoSolicitado, request.MontoSolicitado.Value);
            siniestro.MontoSolicitado = request.MontoSolicitado.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "monto solicitado");
        }



        private void AplicarCambioFechaCarta(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.FechaCarta.Touched || request.FechaCarta.Value == siniestro.FechaCarta) return;
            RegistraCambioBitacora(db, siniestro.Id, "fecha de carta", siniestro.FechaCarta, request.FechaCarta.Value);
            siniestro.FechaCarta = request.FechaCarta.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "fecha de carta");
        }



        private void AplicarCambioTelefono(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.Telefono.Touched || request.Telefono.Value == siniestro.Telefono) return;
            RegistraCambioBitacora(db, siniestro.Id, "teléfono", siniestro.Telefono, request.Telefono.Value);
            siniestro.Telefono = request.Telefono.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "teléfono");
        }

        private void AplicarCambioMonto(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.Monto.Touched || request.Monto.Value == siniestro.Monto) return;
            RegistraMontoCambioBitacora(db, siniestro.Id, "monto", siniestro.Monto, request.Monto.Value);
            siniestro.Monto = request.Monto.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "monto");
        }

        private void AplicarCambioFechaPromesa(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.FechaPromesa.Touched || request.FechaPromesa.Value == siniestro.FechaPromesa) return;
            RegistraCambioBitacora(db, siniestro.Id, "fecha promesa", siniestro.FechaPromesa, request.FechaPromesa.Value);
            siniestro.FechaPromesa = request.FechaPromesa.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "fecha promesa");
        }

        private static string FormatearMonto(int? monto)
        {
            if (!monto.HasValue) return string.Empty;

            NumberFormatInfo nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = ".";
            nfi.NumberDecimalDigits = 0;
            return $"$ {monto.Value.ToString("n", nfi)}";
        }

        private void AplicarCambioNumeroTercero(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.NumeroTercero.Touched || request.NumeroTercero.Value == siniestro.NumeroTercero) return;
            RegistraCambioBitacora(db, siniestro.Id, "número de siniestro tercero", siniestro.NumeroTercero, request.NumeroTercero.Value);
            siniestro.NumeroTercero = request.NumeroTercero.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "número de siniestro tercero");
        }

        private void AplicarCambioCompaniaTercero(GestionSiniestroCommand request, List<string> resultado, Siniestro siniestro, IAppDbContext db)
        {
            if (!request.CompaniaTercero.Touched || request.CompaniaTercero.Value == siniestro.CompaniaTercero) return;

            RegistraCambioBitacora(db, siniestro.Id, "compañía tercero", siniestro.CompaniaTercero, request.CompaniaTercero.Value);
            siniestro.CompaniaTercero = request.CompaniaTercero.Value;
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "compañía tercero");

            db.Entry(siniestro).Reference("Estado").Load();
            if (siniestro.Estado.EtapaId != (int)TiposEtapa.InterBciZenit && new List<string> { "BCI", "ZEN" }
                .Any(t => string.Compare(t, request.CompaniaTercero.Value, StringComparison.InvariantCultureIgnoreCase) == 0))
            {
                siniestro.FechaUltimaActualizacion = DateTime.Now;
                siniestro.FechaUltimoCambioEstado = DateTime.Now;
                siniestro.FechaUltimoCambioEtapa = DateTime.Now;
                siniestro.EstadoId = (int)TiposEstado.IntercompaniaBciZenitCompaniaIdentificada;

                var estadodDestino = db.Estados.AsNoTracking().Single(t => t.Id == siniestro.EstadoId);
                db.EntradasBitacoras.Add(new EntradaBitacora(siniestro.Id, _usuarioActual.Id,
                    (int)TiposCambioEstado.CambioEstado,
                    $"Cambio de estado {siniestro.Estado?.Nombre} a {estadodDestino?.Nombre}"));
            }
            RegistrarMensajeYCambioEnSiniestro(resultado, siniestro, "estudio jurídico");
        }

        private void RegistraCambioBitacora(IAppDbContext db, int siniestroId, string sujeto, string de, string a)
        {
            db.EntradasBitacoras.Add(new EntradaBitacora(siniestroId, _usuarioActual.Id,
                (int)TiposCambioEstado.CambioEstado, $"Cambio de {sujeto} de '{de}' a '{a}'"));
        }

        private void RegistraCambioBitacora(IAppDbContext db, int siniestroId, string sujeto, int? de, int? a)
        {
            RegistraCambioBitacora(db, siniestroId, sujeto,
                de.HasValue ? de.Value.ToString() : string.Empty,
                a.HasValue ? a.Value.ToString() : string.Empty);
        }

        private void RegistraMontoCambioBitacora(IAppDbContext db, int siniestroId, string sujeto, int? de, int? a)
        {
            RegistraCambioBitacora(db, siniestroId, sujeto, FormatearMonto(de), FormatearMonto(a));
        }

        private void RegistraCambioBitacora(IAppDbContext db, int siniestroId, string sujeto, DateTime? de, DateTime? a)
        {
            RegistraCambioBitacora(db, siniestroId, sujeto,
                de.HasValue ? de.Value.ToString("dd-MM-yy") : string.Empty,
                a.HasValue ? a.Value.ToString("dd-MM-yy") : string.Empty);
        }

        private void RegistrarMensajeYCambioEnSiniestro(List<string> resultado, Siniestro siniestro, string sujeto)
        {
            siniestro.FechaUltimaActualizacion = DateTime.Now;
            resultado.Add($"El cambio de {sujeto} ha sido guardado correctamente.");
        }
    }
}