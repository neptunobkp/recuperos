using System.Net.Http;

namespace Recuperos.Aplicacion.Interfaces
{
    public interface IRnvmLocalHttpClientAccessor
    {
        HttpClient Client { get; }
    }

    public interface IConsultaDicomHttpClientAccessor
    {
        HttpClient Client { get; }

    }
}