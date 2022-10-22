using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Etapas.Queries.ListarEtapas
{
    public class ListarEtapasQueryHandler : IRequestHandler<ListarEtapasQuery, IEnumerable<ItemLista>>
    {
        private readonly IGenerateDbContext _db;

        public ListarEtapasQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<ItemLista>> Handle(ListarEtapasQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var etapas = await dbContext.Etapas.Where(t => !t.Eliminado).ToListAsync(cancellationToken);
                return etapas.Select(t => new ItemLista { Id = t.Id.ToString(), Nombre = t.Nombre });
            }
        }
    }
}
