using Recuperos.Modelo.Entidades;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Recuperos.Aplicacion.Interfaces;
using Recuperos.Aplicacion.Interfaces.Servicios.ContentManager;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace Recuperos.Servicios.ContentManager
{
    public class ApiContentManager : IApiContentManager
    {
        private readonly HttpClient _client;
        public ApiContentManager(IContentManagerHttpClientAccessor httpClientAccessor)
        {
            _client = httpClientAccessor.Client;
        }

        public async Task<string> Agregar(Siniestro siniestro, ArchivoAdjunto adjunto, string archivoBase64)
        {
            _client.DefaultRequestHeaders.Add("SOAPAction", "http://www.example.org/LegaltecWSServer/ReceiveReport");
            var metadata = string.Format(ConfigurationManager.AppSettings["ViewCM.Documentos.Agregar.Formato"], siniestro.Numero,
                siniestro.Compania == 1 ? "02" : "03",
                siniestro.Riesgo, siniestro.CodigoSucursal,
                siniestro.TipoDocumento,
                siniestro.Numero,
                siniestro.NumeroItem);
            var payload =
                $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mod=""http://wscm.bciseguros.cl/schema/model"" xmlns:mod1=""http://model.schema.wscm.bciseguros.cl"">
                       <soapenv:Header/>
                       <soapenv:Body>
                          <mod:addDocRequest>
                             <mod:auditoria>
                                <mod1:usuarioWS>{ConfigurationManager.AppSettings["ViewCM.Api.Usuario"]}</mod1:usuarioWS>
                                <mod1:passwordWS>{ConfigurationManager.AppSettings["ViewCM.Api.Contrasena"]}</mod1:passwordWS>
                                <mod1:codigoSistema>{ConfigurationManager.AppSettings["ViewCM.Api.Sistema"]}</mod1:codigoSistema>
                             </mod:auditoria>
                             <mod:sistemaOrigen>ORIGEN</mod:sistemaOrigen>
                             <mod:itemType>Antecedentes</mod:itemType>
                             <mod:metaDatos><![CDATA[{metadata}]]></mod:metaDatos>
                             <mod:documento><![CDATA[<DOCUMENTO><NOMBRE>{Path.GetFileNameWithoutExtension(adjunto.Nombre)}</NOMBRE><EXTENSION>{Path.GetExtension(adjunto.Nombre)}</EXTENSION><ARCHIVO>{archivoBase64}</ARCHIVO><LENGTH>{archivoBase64.Length}</LENGTH></DOCUMENTO>]]></mod:documento>
                             <mod:accion>ADD</mod:accion>
                          </mod:addDocRequest>
                       </soapenv:Body>
                    </soapenv:Envelope>";
            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            var response = await _client.PostAsync("", content);
            var soapResponse = await response.Content.ReadAsStringAsync();
            return DeserializarAgregarResponse(soapResponse);
        }

        public async Task<string> Recuperar(string documentoId)
        {
            _client.DefaultRequestHeaders.Add("SOAPAction", "http://www.example.org/LegaltecWSServer/GetServiceStatus");
            var payload = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mod=""http://wscm.bciseguros.cl/schema/model"" xmlns:mod1=""http://model.schema.wscm.bciseguros.cl"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <mod:getDocRequest>
                                      <mod:auditoria>
                                         <mod1:usuarioWS>{ConfigurationManager.AppSettings["ViewCM.Api.Usuario"]}</mod1:usuarioWS>
                                        <mod1:passwordWS>{ConfigurationManager.AppSettings["ViewCM.Api.Contrasena"]}</mod1:passwordWS>
                                        <mod1:codigoSistema>{ConfigurationManager.AppSettings["ViewCM.Api.Sistema"]}</mod1:codigoSistema>
                                     </mod:auditoria>
                                     <mod:idDocumento>{documentoId}</mod:idDocumento>
                                  </mod:getDocRequest>
                               </soapenv:Body>
                            </soapenv:Envelope>";

            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            var response = await _client.PostAsync("", content);
            var soapResponse = await response.Content.ReadAsStringAsync();

            return DeserializarObtenerResponse(soapResponse);
        }

        public async Task<bool> Eliminar(string documentoId)
        {
            _client.DefaultRequestHeaders.Add("SOAPAction", "http://www.example.org/LegaltecWSServer/GetServiceStatus");
            var payload = $@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:mod=""http://wscm.bciseguros.cl/schema/model"" xmlns:mod1=""http://model.schema.wscm.bciseguros.cl"">
                               <soapenv:Header/>
                               <soapenv:Body>
                                  <mod:delDocRequest>
                                     <mod:auditoria>
                                          <mod1:usuarioWS>{ConfigurationManager.AppSettings["ViewCM.Api.Usuario"]}</mod1:usuarioWS>
                                        <mod1:passwordWS>{ConfigurationManager.AppSettings["ViewCM.Api.Contrasena"]}</mod1:passwordWS>
                                        <mod1:codigoSistema>{ConfigurationManager.AppSettings["ViewCM.Api.Sistema"]}</mod1:codigoSistema>
                                     </mod:auditoria>
                                     <mod:itemType>Antecedentes</mod:itemType>
                                     <mod:idDocumento>{documentoId}</mod:idDocumento>
                                  </mod:delDocRequest>
                               </soapenv:Body>
                            </soapenv:Envelope>";

            var content = new StringContent(payload, Encoding.UTF8, "text/xml");
            var response = await _client.PostAsync("", content);
            var soapResponse = await response.Content.ReadAsStringAsync();
            return soapResponse != null;
        }

        public string DeserializarObtenerResponse(string soapResponse)
        {
            XNamespace ns = "http://wscm.bciseguros.cl/schema/model";
            soapResponse = soapResponse.Replace("soapenv:", "");
            var doc = XDocument.Parse(soapResponse);
            return doc.Descendants("Body").Descendants(ns + "wsContentManagerDocResponse").Descendants(ns + "archivo").FirstOrDefault()?.Value;
        }

        public string DeserializarAgregarResponse(string soapResponse)
        {
            XNamespace ns = "http://wscm.bciseguros.cl/schema/model";
            soapResponse = soapResponse.Replace("soapenv:", "");
            var doc = XDocument.Parse(soapResponse);
            return doc.Descendants("Body").Descendants(ns + "wsContentManagerResponse").Descendants(ns + "idDocumento").FirstOrDefault()?.Value;
        }

    }

    public class AgregarDocumentoResponse
    {
        public string idDocumento { get; set; }
    }

    public class DeserializadorContentResponse
    {

    }
}
