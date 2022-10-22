using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class ResourceResult : ActionResult {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, IList<string>> Errors { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, IList<string>> Information { get; set; }

        public List<Link> Links { get; } = new List<Link>();

        [JsonIgnore]
        public string MediaType => $"application/vnd.pulse.resource+json;profile={Profile}";

        [JsonIgnore]
        public virtual string Profile { get; set; }

        [ResourceIdentifier, JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ResourceId { get; set; }

        public override void ExecuteResult(ControllerContext context) {
            var response = context.HttpContext.Response;
            var settings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter> { new DateTimeConverter() }
            };

            response.ContentType = MediaType;
            response.Write(JsonConvert.SerializeObject(this, settings));
        }

        [JsonIgnore]
        public bool HasErrors => Errors != null && Errors.Count > 0;
    }
}