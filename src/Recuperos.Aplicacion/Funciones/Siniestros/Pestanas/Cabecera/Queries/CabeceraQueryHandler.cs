using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Pestanas.Cabecera.Queries
{
    public class CabeceraQueryHandler : IRequestHandler<CabeceraQuery, SiniestroCabeceraViewModel>
    {
        private readonly IGenerateDbContext _context;
        private readonly IMapper _mapper;
        public CabeceraQueryHandler(IGenerateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SiniestroCabeceraViewModel> Handle(CabeceraQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.FindAsync(cancellationToken, request.Id);
                return _mapper.Map<SiniestroCabeceraViewModel>(siniestro);
            }
        }
    }
}