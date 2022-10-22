using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public interface ISchemaType {
        string Title { get; set; }
        IDictionary<string, object> Attributes { get; set; }
        string Type { get; set; }
        string Format { get; set; }
        string Display { get; set; }
        bool? Disabled { get; set; }
        bool? ReadOnly { get; set; }
        int? Order { get; set; }
        bool? ListItemId { get; set; }
    }

    public interface ISchemaType<out T> : ISchemaType {
    }

    public class SchemaType<T> : ISchemaType<T> {
        public string Title { get; set; }

        [JsonExtensionData]
        public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual string Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ListItemId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReadOnly { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Order { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Display { get; set; }
    }

    public class SchemaType : SchemaType<object> {
    }
}