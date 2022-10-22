using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Aplicacion.Funciones.Siniestros.Bitacora.Queries.ObtenerBitacoraSiniestro
{
    public class ObtenerBitacoraSiniestroQueryHandler : IRequestHandler<ObtenerBitacoraSiniestroQuery, BitacoraResponseViewModel>
    {
        private readonly IGenerateDbContext _context;

        public ObtenerBitacoraSiniestroQueryHandler(IGenerateDbContext context)
        {
            _context = context;
        }

        public async Task<BitacoraResponseViewModel> Handle(ObtenerBitacoraSiniestroQuery request, CancellationToken cancellationToken)
        {
            var resultado = new List<BitacoraViewModel>();
            using (var db = _context.GenerateNewContext())
            {
                IQueryable<EntradaBitacora> bitacoras = db.EntradasBitacoras
                    .Where(t => t.SiniestroId == request.Numero);

                var cantidad = await bitacoras.CountAsync(cancellationToken);

                var skiped = request.Pagina * request.ItemsPorPagina;
                var bitacorasResult = await bitacoras
                    .Include(t => t.Usuario)
                    .Include(t => t.TipoBitacora)
                    .OrderByDescending(t => t.Fecha)
                    .Skip(skiped)
                    .Take(request.ItemsPorPagina)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                foreach (var cadaEntrada in bitacorasResult)
                {
                    var siniestroVm = new BitacoraViewModel()
                    {
                        Fecha = cadaEntrada.Fecha,
                        Usuario = cadaEntrada.Usuario?.Nombres,
                        Hora = cadaEntrada.Hora,
                        Detalle = cadaEntrada.Detalle,
                        Tipo = cadaEntrada.TipoBitacora?.Nombre
                    };
                    resultado.Add(siniestroVm);
                }

                return new BitacoraResponseViewModel()
                {
                    Items = resultado,
                    Total = cantidad
                };
            }

        }
    }
}
