using System.Net.Http;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IRecup02HttpClientAccessor
    {
        HttpClient Client { get; }
    }
}
