using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Etapas.Commands.CrearEtapa
{
    public class CrearEtapaCommandHandler : IRequestHandler<CrearEtapaCommand, int>
    {
        private readonly IGenerateDbContext _db;

        public CrearEtapaCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CrearEtapaCommand request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var result = dbContext.Etapas.Add(new Etapa { Nombre = request.Nombre });
                await dbContext.SaveChangesAsync(cancellationToken);
                return result.Id;
            }
        }
    }
}