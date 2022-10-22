using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public interface ISchemaArray : ISchemaType {
        ISchemaType Items { get; set; }
    }

    public interface ISchemaArray<out T> : ISchemaType<T>, ISchemaArray {
    }

    public class SchemaArray<T> : SchemaType, ISchemaArray<T> {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ISchemaType Items { get; set; }

        public SchemaArray() {
            Type = "array";
        }
    }

    public class SchemaArray : SchemaArray<object> {
    }
}