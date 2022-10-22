using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Aplicacion.Models;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bandejas.Queries.ObtenerSiniestro
{
    public class ObtenerSiniestroQueryHandler : IRequestHandler<ObtenerSiniestroQuery, SiniestroObtenidoViewModel>
    {
        private readonly IGenerateDbContext _db;
        private readonly IMapper _mapper;
        private readonly IApiRecup02 _apiRecup02;

        public ObtenerSiniestroQueryHandler(IGenerateDbContext db, IMapper mapper, IApiRecup02 apiRecup02)
        {
            _db = db;
            _mapper = mapper;
            _apiRecup02 = apiRecup02;
        }

        public async Task<SiniestroObtenidoViewModel> Handle(ObtenerSiniestroQuery request, CancellationToken cancellationToken)
        {
            using (var dbContext = _db.GenerateNewContext())
            {
                var cadaSiniestro = await dbContext.Siniestros
                                            .Include("Estado")
                                            .Include("Ejecutivo")
                                            .SingleAsync(t => t.Id == request.SiniestroId, cancellationToken);

                var resultado = _mapper.Map<SiniestroObtenidoViewModel>(cadaSiniestro);
                resultado.Causal = await _apiRecup02.GetCausal(cadaSiniestro.Numero, cadaSiniestro.Compania);
                resultado.EstadosTransicion = await ObtenerEstadosTransicion(cancellationToken, dbContext, cadaSiniestro);
                return resultado;
            }
        }

        private static async Task<List<ItemLista>> ObtenerEstadosTransicion(CancellationToken cancellationToken, IAppDbContext dbContext, Siniestro cadaSiniestro)
        {
            var data = await dbContext.Transiciones
                .Include(t => t.EstadoDestino)
                .Where(t => t.EstadoOrigenId == cadaSiniestro.EstadoId)
                .OrderBy(t => t.EstadoDestino.Nombre).ToListAsync(cancellationToken);

            return data.Select(t => new ItemLista { Id = t.EstadoDestinoId.ToString(), Nombre = t.EstadoDestino.Nombre }).Distinct().ToList();
        }
    }
}