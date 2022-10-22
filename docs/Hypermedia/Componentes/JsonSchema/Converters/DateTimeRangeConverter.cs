using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters {
    public class DateTimeRangeConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var range = (DateTimeRange)value;
            dynamic timeOnlyRange = new {
                start = range.Start == null ? null : $"{range.Start:yyyy-MM-dd HH:mm:ss}",
                end = range.End == null ? null : $"{range.End:yyyy-MM-dd HH:mm:ss}"
            };
            var jObject = JObject.FromObject(timeOnlyRange);
            jObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if (!CanConvert(objectType)) {
                return null;
            }
            if (reader.TokenType == JsonToken.Null) {
                return null;
            }

            dynamic range = JObject.Load(reader);

            var startRange = new DateTimeOffset();
            if (!string.IsNullOrEmpty(range.start.ToString()) && !DateTimeOffset.TryParse(range.start.ToString(), out startRange)) {
                return null;
            }

            var endRange = new DateTimeOffset();
            if (!string.IsNullOrEmpty(range.end.ToString()) && !DateTimeOffset.TryParse(range.end.ToString(), out endRange)) {
                return null;
            }

            var start = string.IsNullOrEmpty(range.start.ToString()) ? (DateTimeOffset?)null : startRange;
            var end = string.IsNullOrEmpty(range.end.ToString()) ? (DateTimeOffset?)null : endRange;

            return new DateTimeRange(start, end);
        }

        public override bool CanConvert(Type objectType) {
            return typeof(DateTimeRange) == objectType;
        }
    }
}