using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Visar
{
    public class VisarSiniestroCommandHandler : IRequestHandler<VisarSiniestroCommand>
    {
        private readonly IGenerateDbContext _db;
        private readonly IUsuarioActualService _usuarioActual;

        public VisarSiniestroCommandHandler(IGenerateDbContext db, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _usuarioActual = usuarioActual;
        }

        public async Task<Unit> Handle(VisarSiniestroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.Include(t => t.Estado).SingleAsync(t => t.Id == request.Id, cancellationToken);
                var solicitudPendiente = await db.SolicitudesVisto.Include(t => t.EstadoTDestino).SingleAsync(t => t.Id == siniestro.EstadoVisado.Value);

                solicitudPendiente.Aprobado = request.Aceptado;
                solicitudPendiente.Pendiente = false;
                solicitudPendiente.FechaVisado = DateTime.Now;
                solicitudPendiente.VisadorId = _usuarioActual.Id;

                if (request.Aceptado)
                {
                    siniestro.EstadoVisado = null;
                    siniestro.EstadoId = solicitudPendiente.EstadoTDestinoId;
                    siniestro.FechaUltimoCambioEstado = DateTime.Now;

                    if (siniestro.Estado?.EtapaId != solicitudPendiente.EstadoTDestino?.EtapaId)
                    {
                        siniestro.FechaUltimoCambioEtapa = DateTime.Now;
                        siniestro.EjecutivoId = null;
                        siniestro.FechaAsignacion = DateTime.Now.Date;
                    }

                    db.EntradasBitacoras.Add(new EntradaBitacora
                    {
                        UsuarioId = _usuarioActual.Id,
                        SiniestroId = siniestro.Id,
                        Detalle = $"Aprobó cambio de estado {siniestro.Estado?.Nombre} a {solicitudPendiente.EstadoTDestino.Nombre}",
                        TipoBitacoraId = (int)TiposCambioEstado.CambioEstado,
                    });
                }
                else
                {
                    siniestro.EstadoVisado = 0;
                    solicitudPendiente.Detalle = request.Motivo?.Detalle;
                    db.EntradasBitacoras.Add(new EntradaBitacora
                    {
                        UsuarioId = _usuarioActual.Id,
                        SiniestroId = siniestro.Id,
                        Detalle = $"Rechazó cambio de estado {siniestro.Estado?.Nombre} a {solicitudPendiente.EstadoTDestino.Nombre}",
                        TipoBitacoraId = (int)TiposCambioEstado.CambioEstado,
                    });

                    db.EntradasObservaciones.Add(new EntradaObservacion
                    {
                        UsuarioId = _usuarioActual.Id,
                        SiniestroId = siniestro.Id,
                        Detalle = request.Motivo?.Detalle,
                        TipoObservacionId = (int)TiposObservacion.RechazoTransicion,
                        Fecha = DateTime.Now
                    });
                }

                await db.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}