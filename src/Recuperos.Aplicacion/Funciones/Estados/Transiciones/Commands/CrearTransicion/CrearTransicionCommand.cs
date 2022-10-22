using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.CrearTransicion
{
    public class CrearTransicionCommand : IRequest
    {
        public int EstadoOrigenId { get; set; }
        public int[] EstadosDestinoId { get; set; }

        public class CommandHandler : IRequestHandler<CrearTransicionCommand>
        {
            private readonly IGenerateDbContext _db;

            public CommandHandler(IGenerateDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(CrearTransicionCommand request, CancellationToken cancellationToken)
            {
                using (var dbContext = _db.GenerateNewContext())
                {
                    var transiciones = await dbContext.Transiciones.Where(t => t.EstadoOrigenId == request.EstadoOrigenId).ToListAsync(cancellationToken);

                    var transicionesAEliminar = transiciones.Where(t => !request.EstadosDestinoId.Any(p => p == t.EstadoDestinoId));
                    if (transicionesAEliminar.Any())
                    {
                        dbContext.Transiciones.RemoveRange(transicionesAEliminar);
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    var transicionesACrear =
                        request.EstadosDestinoId.Where(p => !transiciones.Any(t => t.EstadoDestinoId == p));

                    if (transicionesACrear.Any())
                    {
                        foreach (var cadaDestino in transicionesACrear)
                        {
                            dbContext.Transiciones.Add(new Transicion
                            {
                                EstadoDestinoId = cadaDestino,
                                EstadoOrigenId = request.EstadoOrigenId
                            });
                        }
                        await dbContext.SaveChangesAsync(cancellationToken);
                    }

                    return Unit.Value;
                }
            }
        }
    }
}
