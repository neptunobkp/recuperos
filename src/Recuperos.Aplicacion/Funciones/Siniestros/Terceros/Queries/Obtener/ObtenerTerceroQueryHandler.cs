using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Obtener
{
    public class ObtenerTerceroQueryHandler : IRequestHandler<ObtenerTerceroQuery, TerceroViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;

        public ObtenerTerceroQueryHandler(IGenerateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TerceroViewModel> Handle(ObtenerTerceroQuery request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                var tercero = await db.Terceros.Include(t => t.Vehiculo)
                    .SingleAsync(t => t.Id == request.Id, cancellationToken);
                return _mapper.Map<TerceroViewModel>(tercero);
            }
        }
    }
}
