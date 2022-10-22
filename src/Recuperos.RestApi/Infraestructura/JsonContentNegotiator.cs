using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;

namespace Recuperos.RestApi.Infraestructura
{
    public class JsonContentNegotiator : IContentNegotiator
    {
        public JsonMediaTypeFormatter JsonFormatter { get; private set; }

        public JsonContentNegotiator(JsonMediaTypeFormatter jsonFormatter)
        {
            JsonFormatter = jsonFormatter;
        }

        public ContentNegotiationResult Negotiate(Type type, System.Net.Http.HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            JsonFormatter.UseDataContractJsonSerializer = false;

            return new ContentNegotiationResult(JsonFormatter, new MediaTypeHeaderValue("application/vnd.pulse.resource+json")); 
        }
    }
}