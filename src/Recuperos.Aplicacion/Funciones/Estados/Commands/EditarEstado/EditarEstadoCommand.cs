using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Commands.EditarEstado
{
    public class EditarEstadoCommand : IRequest
    {
        public string Nombre { get; set; }

        public string Id { get; set; }

        public class HandleCommand : IRequestHandler<EditarEstadoCommand>
        {
            private readonly IGenerateDbContext _db;

            public HandleCommand(IGenerateDbContext db)
            {
                _db = db;
            }

            public async Task<Unit> Handle(EditarEstadoCommand request, CancellationToken cancellationToken)
            {
                using (var dbContext = _db.GenerateNewContext())
                {
                    var estado = await dbContext.Estados.FindAsync(cancellationToken, System.Convert.ToInt32(request.Id));
                    estado.Nombre = request.Nombre;
                    await dbContext.SaveChangesAsync(cancellationToken);
                    return Unit.Value;
                }
            }
        }
    }
}
