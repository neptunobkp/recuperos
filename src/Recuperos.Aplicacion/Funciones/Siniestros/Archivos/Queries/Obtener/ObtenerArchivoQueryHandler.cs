using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Obtener
{
    public class ObtenerArchivoQueryHandler : IRequestHandler<ObtenerArchivoQuery, ArchivoObtenidoViewModel>
    {
        private readonly IGenerateDbContext _context;
        private readonly IApiContentManager _contentManager;

        public ObtenerArchivoQueryHandler(IGenerateDbContext context, IApiContentManager contentManager)
        {
            _context = context;
            _contentManager = contentManager;
        }

        public async Task<ArchivoObtenidoViewModel> Handle(ObtenerArchivoQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var archivo = await db.Archivos.FindAsync(cancellationToken, request.Id);
                var data = await _contentManager.Recuperar(archivo.Url);
                return new ArchivoObtenidoViewModel
                {
                    Nombre = archivo.Nombre,
                    ContentType = archivo.Extension,
                    Buffer = Convert.FromBase64String(data)
                };
            }
        }
    }
}