using System;
using Newtonsoft.Json;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    [JsonConverter(typeof(TimeRangeConverter))]
    public class TimeRange {
        public DateTimeOffset? Start { get; }
        public DateTimeOffset? End { get; }

        public TimeRange Normalize() {
            var start = Start.HasValue ? new DateTimeOffset(1, 1, 1, Start.Value.Hour, Start.Value.Minute, Start.Value.Second, TimeSpan.Zero) :
                new DateTimeOffset(1, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var end = End.HasValue ? new DateTimeOffset(1, 1, 1, End.Value.Hour, End.Value.Minute, End.Value.Second, TimeSpan.Zero) :
                new DateTimeOffset(1, 1, 2, 0, 0, 0, TimeSpan.Zero);
            if (start > end) {
                end = end.AddDays(1);
            }
            return new TimeRange(start, end);
        }

        public TimeRange(DateTimeOffset? start, DateTimeOffset? end) {
            Start = start;
            End = end;
        }

        public bool IsVoid() {
            return !Start.HasValue && !End.HasValue;
        }
    }
}