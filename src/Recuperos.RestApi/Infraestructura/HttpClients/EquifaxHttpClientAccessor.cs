using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.RestApi.Infraestructura.HttpClients
{
    public class EquifaxHttpClientAccessor : IEquifaxHttpClientAccessor, IDisposable
    {
        public HttpClient Client { get; }

        public EquifaxHttpClientAccessor()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Equifax.Api.Url"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Client?.Dispose();
        }
    }
}