using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Commands.EliminarEstado
{
    public class EliminarEstadoCommand : IRequest
    {
        public string Id { get; set; }

        public class CommandHandler : IRequestHandler<EliminarEstadoCommand>
        {
            private readonly IGenerateDbContext _db;

            public CommandHandler(IGenerateDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(EliminarEstadoCommand request, CancellationToken cancellationToken)
            {
                using (var dbContext = _db.GenerateNewContext())
                {
                    var estado = await dbContext.Estados.FindAsync(cancellationToken, Convert.ToInt32(request.Id));
                    estado.Eliminado = true;
                    await dbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
            }
        }
    }
}
