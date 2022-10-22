using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.EditarEtapa
{
    public class EditarEtapaCommandHandler : IRequestHandler<EditarEtapaCommand>
    {
        private readonly IGenerateDbContext _db;

        public EditarEtapaCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(EditarEtapaCommand request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var etapa = await dbContext.Etapas.FirstOrDefaultAsync(t => t.Id == request.Id);
                etapa.Nombre = request.Nombre;
                await dbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}