using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Recuperos.Aplicacion.Interfaces;

namespace Recuperos.RestApi.Infraestructura.HttpClients
{
    public class Recup02HttpClientAccessor : IRecup02HttpClientAccessor, IDisposable
    {
        public HttpClient Client { get; }

        public Recup02HttpClientAccessor()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["Recup02.Api.Url"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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