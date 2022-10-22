using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Observaciones.Queries.ObtenerObservacionesSiniestro
{
    public class ObtenerObservacionesSiniestroQueryHandler : IRequestHandler<ObtenerObservacionesSiniestroQuery, ObservacionesResponseViewModel>
    {
        private readonly IGenerateDbContext _context;

        public ObtenerObservacionesSiniestroQueryHandler(IGenerateDbContext context)
        {
            _context = context;
        }

        public async Task<ObservacionesResponseViewModel> Handle(ObtenerObservacionesSiniestroQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<ObservacionViewModel>();
            using (var db = _context.GenerateNewContext())
            {
                IQueryable<EntradaObservacion> observaciones = db.EntradasObservaciones
                    .Where(t => t.SiniestroId == request.SiniestroId);

                var cantidad = await observaciones.CountAsync(cancellationToken);

                var skiped = request.Pagina * request.ItemsPorPagina;
                var observacionesResult = await observaciones
                    .Include(t => t.Usuario)
                    .Include(t => t.TipoObservacion)
                    .OrderByDescending(t => t.Fecha)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                foreach (var cadaEntrada in observacionesResult)
                {
                    var siniestroVm = new ObservacionViewModel()
                    {
                        Fecha = cadaEntrada.Fecha,
                        Usuario = cadaEntrada.Usuario?.Nombres,
                        Hora = cadaEntrada.Hora,
                        Detalle = cadaEntrada.Detalle,
                        Tipo = cadaEntrada.TipoObservacion?.Nombre
                    };
                    resultado.Add(siniestroVm);
                }

                return new ObservacionesResponseViewModel()
                {
                    Items = resultado,
                    Total = cantidad
                };
            }

        }
    }
}
