using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public interface ISchemaObject : ISchemaType {
        IDictionary<string, SchemaType> Properties { get; set; }
        IList<string> Required { get; set; }
    }

    public interface ISchemaObject<out T> : ISchemaType<T>, ISchemaObject {
    }

    public class SchemaObject<T> : SchemaType, ISchemaObject<T> {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, SchemaType> Properties { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<string> Required { get; set; }

        public SchemaObject(string type = "object") {
            Type = type;
        }
    }

    public class SchemaObject : SchemaObject<object> { }
}