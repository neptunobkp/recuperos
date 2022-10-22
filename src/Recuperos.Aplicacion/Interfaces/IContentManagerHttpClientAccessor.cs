using System.Net.Http;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IContentManagerHttpClientAccessor
    {
        HttpClient Client { get; }
    }
}