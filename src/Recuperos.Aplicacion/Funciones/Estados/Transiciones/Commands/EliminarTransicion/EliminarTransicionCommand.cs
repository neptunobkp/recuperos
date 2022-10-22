using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.EliminarTransicion
{
    public class EliminarTransicionCommand : IRequest
    {
        public int EstadoOrigenId { get; set; }
        public int EstadoDestinoId { get; set; }

        public class CommandHandler : IRequestHandler<EliminarTransicionCommand>
        {
            private readonly IGenerateDbContext _db;

            public CommandHandler(IGenerateDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(EliminarTransicionCommand request, CancellationToken cancellationToken)
            {
                using (var dbContext = _db.GenerateNewContext())
                {
                    var transiciones = await dbContext.Transiciones
                        .Where(t => t.EstadoOrigenId == request.EstadoOrigenId &&
                                    t.EstadoDestinoId == request.EstadoDestinoId).ToListAsync(cancellationToken);
                    dbContext.Transiciones.RemoveRange(transiciones);
                    await dbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
            }
        }
    }
}
