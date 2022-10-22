using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.Recup02;

namespace Recuperos.Aplicacion.Funciones.Servicios.Recup02.GetVehiculo
{
    public class GetVehiculoQueryHandler : IRequestHandler<GetVehiculoQuery, HttpResponseMessage>
    {
        private readonly IApiRecup02 _apiRecup02;
        private readonly IGenerateDbContext _context;

        public GetVehiculoQueryHandler(IApiRecup02 apiRecup02, IGenerateDbContext context)
        {
            _apiRecup02 = apiRecup02;
            _context = context;
        }

        public async Task<HttpResponseMessage> Handle(GetVehiculoQuery request, CancellationToken cancellationToken)
        {
            using (var db = _context.GenerateNewContext())
            {
                var siniestro = db.Siniestros.Find(request.Numero);
                return await _apiRecup02.GetVehiculo(siniestro.Numero, siniestro.Compania);
            }
        }
    }
}
