using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.EliminarEtapa
{
    public class EliminarEtapaCommand : IRequest
    {
        public int Id { get; set; }

        public class CommandHandler : IRequestHandler<EliminarEtapaCommand>
        {
            private readonly IGenerateDbContext _db;

            public CommandHandler(IGenerateDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(EliminarEtapaCommand request, CancellationToken cancellationToken)
            {
                using (var dbContext = _db.GenerateNewContext())
                {
                    var etapa = await dbContext.Etapas.FindAsync(cancellationToken, request.Id);
                    etapa.Eliminado = true;
                    await dbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
            }
        }
    }
}
