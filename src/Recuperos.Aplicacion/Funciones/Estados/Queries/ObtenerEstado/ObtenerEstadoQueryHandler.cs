using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Estados.Queries.ObtenerEstado
{
    public class ObtenerEstadoQueryHandler : IRequestHandler<ObtenerEstadoQuery, ItemLista>
    {
        private readonly IGenerateDbContext _db;

        public ObtenerEstadoQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<ItemLista> Handle(ObtenerEstadoQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var result = await dbContext.Estados.FindAsync(cancellationToken, request.Id);
                return new ItemLista() { Id = result.Id.ToString(), Nombre = result.Nombre };
            }
        }
    }
}