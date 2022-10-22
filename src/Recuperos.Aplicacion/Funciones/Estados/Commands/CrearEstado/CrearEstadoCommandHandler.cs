using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Estados.Commands.CrearEstado
{
    public class CrearEstadoCommandHandler : IRequestHandler<CrearEstadoCommand, int>
    {
        private readonly IGenerateDbContext _db;

        public CrearEstadoCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CrearEstadoCommand request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var result = dbContext.Estados.Add(new Estado() { Nombre = request.Nombre, EtapaId = System.Convert.ToInt32(request.EtapaId) });
                await dbContext.SaveChangesAsync(cancellationToken);
                return result.Id;
            }
        }
    }
}