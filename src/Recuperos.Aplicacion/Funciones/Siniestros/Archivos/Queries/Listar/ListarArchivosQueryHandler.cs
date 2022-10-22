using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Archivos.Queries.Listar
{
    public class ListarArchivosQueryHandler : IRequestHandler<ListarArchivosQuery, IEnumerable<ArchivoAdjuntoViewModel>>
    {
        private readonly IGenerateDbContext _context;
        private readonly IMapper _mapper;

        public ListarArchivosQueryHandler(IGenerateDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArchivoAdjuntoViewModel>> Handle(ListarArchivosQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var archivos = await db.Archivos.Include(t => t.Usuario).Where(t => t.SiniestroId == request.SiniestroId)
                    .ToListAsync(cancellationToken);
                return _mapper.Map<IEnumerable<ArchivoAdjuntoViewModel>>(archivos);
            }
        }
    }
}