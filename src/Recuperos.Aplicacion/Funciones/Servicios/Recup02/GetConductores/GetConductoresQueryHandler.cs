using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetConductores
{
    public class GetConductoresQueryHandler : IRequestHandler<GetConductoresQuery, HttpResponseMessage>
    {
        private readonly IApiRecup02 _apiRecup02;
        private readonly IGenerateDbContext _context;

        public GetConductoresQueryHandler(IApiRecup02 apiRecup02, IGenerateDbContext context)
        {
            _apiRecup02 = apiRecup02;
            _context = context;
        }

        public async Task<HttpResponseMessage> Handle(GetConductoresQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = await db.Siniestros.FindAsync(cancellationToken, request.Numero);
                return await _apiRecup02.GetConductores(siniestro.Numero, siniestro.NumeroPoliza, siniestro.CodigoSucursal, siniestro.TipoDocumento, siniestro.NumeroItem, siniestro.Compania);
            }
        }
    }
}
