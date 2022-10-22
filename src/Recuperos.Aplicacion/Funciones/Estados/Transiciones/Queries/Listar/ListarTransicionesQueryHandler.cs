using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar
{
    public class ListarTransicionesQueryHandler : IRequestHandler<ListarTransicionesQuery, List<ItemTransicionDto>>
    {
        private readonly IGenerateDbContext _db;
        public ListarTransicionesQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<List<ItemTransicionDto>> Handle(ListarTransicionesQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<ItemTransicionDto>();
            using (var dbContext = _db.GenerateNewContext())
            {
                var transicionesDb = await dbContext.Transiciones
                    .AsNoTracking()
                    .Where(t => t.EstadoOrigenId == request.EstadoId)
                    .ToListAsync(cancellationToken);

                var etapasDb = await dbContext.Etapas
                    .AsNoTracking()
                    .Where(t => !t.Eliminado)
                    .ToListAsync(cancellationToken);

                foreach (var cadaEtapa in etapasDb.OrderBy(t => t.Nombre))
                {
                    var estadosEtapa = await dbContext.Estados
                        .AsNoTracking()
                        .Where(t => t.EtapaId == cadaEtapa.Id && !t.Eliminado)
                        .ToListAsync(cancellationToken);

                    var nodo = new ItemTransicionDto { Item = cadaEtapa.Nombre };
                    if (estadosEtapa.Count > 0)
                    {
                        nodo.Children = new List<ItemTransicionDto>();
                        foreach (var cadaEstado in estadosEtapa.OrderBy(t => t.Nombre))
                        {
                            nodo.Children.Add(new ItemTransicionDto
                            {
                                Item = cadaEstado.Nombre,
                                Id = cadaEstado.Id.ToString(),
                                Seleccionado = transicionesDb.Any(t => t.EstadoDestinoId == cadaEstado.Id)
                            });
                        }
                        resultado.Add(nodo);
                    }
                }
                return resultado;
            }
        }
    }
}