using System.Net.Http;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IEquifaxHttpClientAccessor
    {
        HttpClient Client { get; }
    }
}
