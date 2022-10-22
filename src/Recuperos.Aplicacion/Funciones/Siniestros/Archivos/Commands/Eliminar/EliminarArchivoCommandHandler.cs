using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Commands.Eliminar
{
    public class EliminarArchivoCommandHandler : IRequestHandler<EliminarArchivoCommand>
    {
        private readonly IGenerateDbContext _context;
        private readonly IApiContentManager _contentManager;

        public EliminarArchivoCommandHandler(IGenerateDbContext context, IApiContentManager contentManager)
        {
            _context = context;
            _contentManager = contentManager;
        }

        public async Task<Unit> Handle(EliminarArchivoCommand request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var archivo = await db.Archivos.FindAsync(cancellationToken, request.Id);
                await _contentManager.Eliminar(archivo.Url);
                db.Archivos.Remove(archivo);
                await db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}