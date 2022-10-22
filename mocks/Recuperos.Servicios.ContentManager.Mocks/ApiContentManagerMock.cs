using System;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;
using Recuperos.Modelo.Entidades;

namespace Recuperos.Servicios.ContentManager.Mocks
{
    public class ApiContentManagerMock : IApiContentManager
    {
        public Task<string> Agregar(Siniestro siniestro, ArchivoAdjunto adjunto, string archivoBase64)
        {
            return Task.FromResult("AA" + DateTime.Now.Ticks);
        }

        public Task<string> Recuperar(string documentoId)
        {
            return Task.FromResult("YXJjaGl2byBkZSBwcnVlYmEgcGFyYSB0ZXN0ZWFyIGxhIGNvbmZpZ3VyYWNpb24gMw0K");
        }

        public Task<bool> Eliminar(string documentoId)
        {
            return Task.FromResult(true);
        }
    }
}
