using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;
using Recuperos.Modelo.Entidades;
using Recuperos.Modelo.Tipos;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetFacturas
{
    public class GetFacturasQueryHandler : IRequestHandler<GetFacturasQuery, FacturasResponseViewModel>
    {
        private readonly IApiRecup02 _apiRecup02;
        private readonly IGenerateDbContext _context;
        public GetFacturasQueryHandler(IApiRecup02 apiRecup02, IGenerateDbContext context)
        {
            _apiRecup02 = apiRecup02;
            _context = context;
        }

        public async Task<FacturasResponseViewModel> Handle(GetFacturasQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.FindAsync(cancellationToken, request.Numero);
                return new FacturasResponseViewModel
                {
                    UrlBase = $"{ConfigurationManager.AppSettings["Facturas.Url"]}/{EtiquetaFacturaCompania(siniestro)}",
                    Items = await _apiRecup02.GetFacturas(siniestro.Numero, siniestro.Compania)
                };
            }
        }

        private static string EtiquetaFacturaCompania(Siniestro siniestro)
        {
            return siniestro.Compania == (int)TiposCompania.Zenit ? "FacturasZenit" : "Facturas";
        }
    }
}
