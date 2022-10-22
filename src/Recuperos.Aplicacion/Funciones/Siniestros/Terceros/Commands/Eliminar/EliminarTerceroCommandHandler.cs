using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Commands.Eliminar
{
    public class EliminarTerceroCommandHandler : IRequestHandler<EliminarTerceroCommand>
    {
        private readonly IGenerateDbContext _db;

        public EliminarTerceroCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(EliminarTerceroCommand request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var tercero = await db.Terceros.Include(t => t.Vehiculo).SingleAsync(t => t.Id == request.Id, cancellationToken);
                db.Terceros.Remove(tercero);
                await db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}