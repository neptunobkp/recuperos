using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Estados.Queries.ListarEstados
{
    public class ListarEstadosQueryHandler : IRequestHandler<ListarEstadosQuery, IEnumerable<ItemLista>>
    {
        private readonly IGenerateDbContext _db;

        public ListarEstadosQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ItemLista>> Handle(ListarEstadosQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var estados = await dbContext.Estados.Where(t => t.EtapaId == request.EtapaId && !t.Eliminado)
                    .ToListAsync(cancellationToken);
                return estados.OrderBy(t => t.Nombre).Select(t => new ItemLista { Id = t.Id.ToString(), Nombre = t.Nombre });
            }
        }
    }
}
