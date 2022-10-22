using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Etapas.Queries.ObtenerEtapa
{
    public class ObtenerEtapaQueryHandler : IRequestHandler<ObtenerEtapaQuery, ItemLista>
    {
        private readonly IGenerateDbContext _db;

        public ObtenerEtapaQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<ItemLista> Handle(ObtenerEtapaQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var result = await dbContext.Etapas.FindAsync(cancellationToken, request.Id);
                return new ItemLista() { Id = result.Id.ToString(), Nombre = result.Nombre };
            }
        }
    }
}