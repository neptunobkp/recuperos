using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Estados.Transiciones.Commands.CambiarCertificables
{
    public class CambiarCertificablesCommand : IRequest
    {
        public int EstadoOrigen { get; set; }
        public int[] EstadosMarcados { get; set; }
    }

    public class CambiarCertificablesCommandHandler : IRequestHandler<CambiarCertificablesCommand>
    {
        private readonly IGenerateDbContext _db;

        public CambiarCertificablesCommandHandler(IGenerateDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(CambiarCertificablesCommand request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var transiciones = await dbContext.Transiciones.Where(t => t.EstadoOrigenId == request.EstadoOrigen).ToListAsync(cancellationToken);
                foreach (var cadaTransicion in transiciones)
                {
                    cadaTransicion.Aprobable = request.EstadosMarcados.Any(t => t == cadaTransicion.Id);
                }
                await dbContext.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
