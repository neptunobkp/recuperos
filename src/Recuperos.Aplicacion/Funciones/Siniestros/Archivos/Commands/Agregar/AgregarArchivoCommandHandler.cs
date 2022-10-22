using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Autorizacion;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Agregar
{
    public class AgregarArchivoCommandHandler : IRequestHandler<AgregarArchivoCommand>
    {
        private readonly IGenerateDbContext _context;
        private readonly IApiContentManager _contentManager;
        private readonly IUsuarioActualService _usuarioActual;

        public AgregarArchivoCommandHandler(IGenerateDbContext context, IApiContentManager contentManager, IUsuarioActualService usuarioActual)
        {
            _context = context;
            _contentManager = contentManager;
            _usuarioActual = usuarioActual;
        }


        public async Task<Unit> Handle(AgregarArchivoCommand request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.FindAsync(cancellationToken, request.SiniestroId);
                var archivoAdjunto = new ArchivoAdjunto
                {
                    Nombre = request.Nombre,
                    Extension = request.Extension,
                    SiniestroId = request.SiniestroId,
                    Fecha = DateTime.Now,
                    UsuarioId = _usuarioActual.Id
                };
                archivoAdjunto.Url = await _contentManager.Agregar(siniestro, archivoAdjunto, request.Data);
                db.Archivos.Add(archivoAdjunto);
                await db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}