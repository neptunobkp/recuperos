using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public class JsonSchemaConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(ISchemaType).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jObject = JObject.Load(reader);
            object target;

            var schematype = jObject.Properties().FirstOrDefault(p => p.Name == "Type")?.Value.Value<string>();

            if (schematype == "object" || jObject.Properties().Any(p => p.Name == "Properties")) {
                target = new SchemaObject();
            }
            else if (schematype == "array" || jObject.Properties().Any(p => p.Name == "Items")) {
                target = new SchemaArray();
            }
            else if (jObject.Properties().Any(p => p.Name == "Enum")) {
                target = new SchemaEnum();
            }
            else {
                target = Activator.CreateInstance(objectType);
            }

            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}