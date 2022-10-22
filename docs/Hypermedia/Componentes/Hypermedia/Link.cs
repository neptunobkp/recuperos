using System;
using Newtonsoft.Json;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia {
    public class Link {
        public Uri Href { get; set; }

        public string Rel { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string DisallowedIndexes { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Target { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public SchemaObject Template { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ResourceId { get; set; }
    }
}