using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.Listar;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Queries.ListarCertificables
{
    public class ListarCertificablesQuery : EstadoIdentificable, IRequest<List<ItemTransicionDto>>
    {
    }

    public class ListarCertificablesQueryHandler : IRequestHandler<ListarCertificablesQuery, List<ItemTransicionDto>>
    {
        private readonly IGenerateDbContext _db;

        public ListarCertificablesQueryHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<List<ItemTransicionDto>> Handle(ListarCertificablesQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<ItemTransicionDto>();
            using (var dbContext = _db.GenerateNewContext())
            {
                var transicionesDb = await dbContext.Transiciones
                    .Include(t => t.EstadoDestino.Etapa)
                    .AsNoTracking()
                    .Where(t => t.EstadoOrigenId == request.EstadoId)
                    .ToListAsync(cancellationToken);

                var idsEtapa = transicionesDb.Select(t => t.EstadoDestino.Etapa.Id).Distinct();
                foreach (var cadaEtapa in idsEtapa)
                {
                    var transicionesEtapa = transicionesDb.Where(t => t.EstadoDestino.EtapaId == cadaEtapa).ToList();

                    if (!transicionesEtapa.Any()) continue;
                    var nodo = new ItemTransicionDto
                    {
                        Item = transicionesEtapa[0].EstadoDestino.Etapa.Nombre,
                        Children = new List<ItemTransicionDto>()
                    };
                    foreach (var cadaTransicionEtapa in transicionesEtapa)
                    {
                        nodo.Children.Add(new ItemTransicionDto
                        {
                            Item = cadaTransicionEtapa.EstadoDestino.Nombre,
                            Id = cadaTransicionEtapa.Id.ToString(),
                            Seleccionado = cadaTransicionEtapa.Aprobable.GetValueOrDefault()
                        });
                    }
                    resultado.Add(nodo);
                }
            }

            return resultado;
        }
    }

}
