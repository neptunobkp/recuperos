using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters {
    public class SelectConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var list = (Select)value;
            dynamic selectList = new { valueOnClear = list.ValueOnClear, placeholder = list.Placeholder, value = list.Value, options = list.Options.Select(x => new { title = x.Title, value = x.Value }) };
            var jObject = JObject.FromObject(selectList);
            jObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            return new object();
        }

        public override bool CanConvert(Type objectType) {
            return typeof(Select) == objectType;
        }
    }
}