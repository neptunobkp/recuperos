using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Models;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerTiposObervacion
{
    public class ObtenerTiposObervacionQueryHandler : IRequestHandler<ObtenerTiposObervacionQuery, IEnumerable<ItemLista>>
    {

        private readonly IGenerateDbContext _db;

        public ObtenerTiposObervacionQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ItemLista>> Handle(ObtenerTiposObervacionQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var estados = await dbContext.TiposObservacion.ToListAsync(cancellationToken);
                return estados.Where(t => !t.Eliminado).OrderBy(t => t.Nombre).Select(t => new ItemLista { Id = t.Id.ToString(), Nombre = t.Nombre });
            }
        }
    }
}
