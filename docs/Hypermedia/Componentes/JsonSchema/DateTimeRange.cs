using System;
using Newtonsoft.Json;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    [JsonConverter(typeof(DateTimeRangeConverter))]
    public class DateTimeRange {
        public DateTimeOffset? Start { get; }
        public DateTimeOffset? End { get; }

        public TimeSpan Span {
            get {
                var normalized = Normalize();
                return normalized.End.Value - normalized.Start.Value;
            }
        }

        public DateTimeRange Normalize() {
            return new DateTimeRange(Start ?? DateTimeOffset.MinValue, End ?? DateTimeOffset.MaxValue);
        }

        public DateTimeRange(DateTimeOffset? start, DateTimeOffset? end) {
            Start = start;
            End = end;
        }

        public bool IsVoid() {
            return !Start.HasValue && !End.HasValue;
        }
    }
}