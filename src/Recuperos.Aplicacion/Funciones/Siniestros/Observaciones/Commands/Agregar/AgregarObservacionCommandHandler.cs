using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Commands.Agregar
{
    public class AgregarObservacionCommandHandler : IRequestHandler<AgregarObservacionCommand>
    {
        private readonly IGenerateDbContext _db;
        private readonly IUsuarioActualService _usuarioActual;
        public AgregarObservacionCommandHandler(IGenerateDbContext db, IUsuarioActualService usuarioActual)
        {
            _usuarioActual = usuarioActual;
            _db = db;
        }

        public async Task<Unit> Handle(AgregarObservacionCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                db.EntradasObservaciones.Add(new EntradaObservacion
                {
                    TipoObservacionId = request.TipoObservacionId,
                    Detalle = request.Detalle,
                    SiniestroId = request.SiniestroId,
                    UsuarioId = _usuarioActual.Id,
                    Fecha = DateTime.Now,
                    Hora = DateTime.Now.ToShortTimeString()
                });

                await db.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
