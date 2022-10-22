using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters {
    public class DateTimeConverter : IsoDateTimeConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            if (value is DateTime) {
                var text = ((DateTime)value).Date.ToString("yyyy-MM-dd");
                writer.WriteValue(text);
            }
            else {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}