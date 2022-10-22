using System;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Commands.Asignar
{
    public class AsignarCommandHandler : IRequestHandler<AsignarCommand>
    {
        private readonly IGenerateDbContext _db;
        private readonly IUsuarioActualService _usuarioActual;
        public AsignarCommandHandler(IGenerateDbContext db, IUsuarioActualService usuarioActual)
        {
            _db = db;
            _usuarioActual = usuarioActual;
        }
        public async Task<Unit> Handle(AsignarCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var siniestro =
                    await db.Siniestros.Include(t => t.Estado).SingleAsync(t => t.Id == request.SiniestroId);
                var asignable = await db.Usuarios.AsNoTracking().SingleAsync(t => t.Id == request.EjecutivoId, cancellationToken);

                siniestro.EjecutivoId = request.EjecutivoId;
                siniestro.ActualizadoPor = asignable.Nombres;
                siniestro.FechaAsignacion = DateTime.Now.Date;
                siniestro.FechaUltimaActualizacion = DateTime.Now;

                var entradBitacora = ConfigurarEntradaBitacora(request, asignable);
                db.EntradasBitacoras.Add(entradBitacora);

                if (siniestro.Estado.EtapaId == (int)TiposEtapa.AsignacionJudicial)
                {
                    
                    siniestro.FechaUltimoCambioEstado = DateTime.Now;
                    siniestro.FechaUltimoCambioEtapa = DateTime.Now;
                    siniestro.EstadoId = (int)TiposEstado.EstudiosJuridicosEstudiosJuridicos;
                    siniestro.EstudioAbogados = asignable.Nombres;
                    var estadodDestino = await db.Estados.AsNoTracking().SingleAsync(t => t.Id == siniestro.EstadoId, cancellationToken);
                    db.EntradasBitacoras.Add(new EntradaBitacora(request.SiniestroId, _usuarioActual.Id, (int)TiposCambioEstado.CambioEstado, $"Cambio de estado {siniestro.Estado?.Nombre} a {estadodDestino?.Nombre}"));
                }

                await db.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }

        private static EntradaBitacora ConfigurarEntradaBitacora(AsignarCommand request, Usuario asignable)
        {
            var entradBitacora = new EntradaBitacora
            {
                SiniestroId = request.SiniestroId,
                Fecha = DateTime.Now,
                Detalle = $"asignó el siniestro a {asignable.Nombres}.",
                TipoBitacoraId = (int)TiposCambioEstado.CambioProbabilidad,
                Hora = DateTime.Now.ToShortTimeString(),
                UsuarioId = request.OwnerId
            };
            return entradBitacora;
        }
    }
}
