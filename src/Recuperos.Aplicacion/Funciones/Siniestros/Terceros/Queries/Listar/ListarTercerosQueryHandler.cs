using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Terceros.Queries.Listar
{
    public class ListarTercerosQueryHandler : IRequestHandler<ListarTercerosQuery, PaginaListableTerceroViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;

        public ListarTercerosQueryHandler(IGenerateDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PaginaListableTerceroViewModel> Handle(ListarTercerosQuery request, CancellationToken cancellationToken)
        {
            using (var db = _db.GenerateNewContext())
            {
                IQueryable<Tercero> queryTercero = db.Terceros.Where(t => t.SiniestroId == request.SiniestroId);
                var cantidad = await queryTercero.CountAsync(cancellationToken);
                var skiped = request.Pagina * request.ItemsPorPagina;
                var tercerosResult = await queryTercero
                    .Include(t => t.Vehiculo)
                    .OrderBy(t => t.Id)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                var infoPersonas = await db.InfoPersonas
                    .Include(t => t.Direcciones)
                    .Include(t => t.Telefonos)
                    .Include(t => t.Correos)
                    .Where(t => t.SiniestroId == request.SiniestroId)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                var result = new PaginaListableTerceroViewModel();

                foreach (var cadaTercero in tercerosResult)
                {
                    var itemListable = _mapper.Map<ItemListableTerceroViewModel>(cadaTercero);
                    var infoPersona = infoPersonas.FirstOrDefault(t => t.TerceroId == cadaTercero.Id);
                    if (infoPersona != null)
                    {
                        itemListable.Direcciones = _mapper.Map<List<DireccionViewModel>>(infoPersona.Direcciones);
                        itemListable.Telefonos = _mapper.Map<List<TelefonoViewModel>>(infoPersona.Telefonos);
                        itemListable.Correos = _mapper.Map<List<CorreoViewModel>>(infoPersona.Correos);
                    }
                    result.Items.Add(itemListable);
                }

                result.Total = cantidad;

                return result;
            }
        }
    }
}
