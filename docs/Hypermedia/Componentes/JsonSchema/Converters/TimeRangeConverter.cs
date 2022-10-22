using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters {
    public class TimeRangeConverter : JsonConverter {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            var range = (TimeRange) value;
            dynamic timeOnlyRange = new {
                start = range.Start == null ? null : $"{range.Start:HH:mm:ss}",
                end = range.End == null ? null : $"{range.End:HH:mm:ss}"
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

            var startRange = new TimeSpan();
            if (!string.IsNullOrEmpty(range.start.ToString()) && !TimeSpan.TryParse(range.start.ToString(), out startRange)) {
                return null;
            }
            var endRange = new TimeSpan();
            if (!string.IsNullOrEmpty(range.end.ToString()) &&!TimeSpan.TryParse(range.end.ToString(), out endRange)) {
                return null;
            }
            var now = DateTimeOffset.UtcNow;
            var start = string.IsNullOrEmpty(range.start.ToString()) ? (DateTimeOffset?) null :
                new DateTimeOffset(now.Year, now.Month, now.Day, startRange.Hours, startRange.Minutes, startRange.Seconds, TimeSpan.FromHours(0));
            var end = string.IsNullOrEmpty(range.end.ToString()) ? (DateTimeOffset?)null : 
                new DateTimeOffset(now.Year, now.Month, now.Day, endRange.Hours, endRange.Minutes, endRange.Seconds, TimeSpan.FromHours(0));

            return new TimeRange(start, end);
        }

        public override bool CanConvert(Type objectType) {
            return typeof(TimeRange) == objectType;
        }
    }
}