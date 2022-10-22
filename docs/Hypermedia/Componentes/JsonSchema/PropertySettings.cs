using System.Collections.Generic;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class PropertyFormatType {
        public const string Text = "text";
        public const string TextArea = "textarea";
        public const string Date = "date";
        public const string DateTime = "date-time";
        public const string DateTimeRelative = "date-time+relative";
        public const string TimeOfDay = "time-of-day";
        public const string Html = "code+html";
        public const string CSharp = "code+csharp";
        public const string JavaScript = "code+javascript";
        public const string Css = "code+css";
        public const string Json = "code+json";
        public const string File = "file";
        public const string Clipboard = "clipboard";
        public const string ListToggle = "list-toggle";
        public const string Select = "select";
        public const string Diff = "diff";
    }

    public static class DisplayType {
        public const string Select = "select";
        public const string Advanced = "advanced";
    }

    public class PropertySettings {
        [JsonIgnore]
        public string Title { get; set; }
        [JsonIgnore]
        public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        public bool IsRequired { get; set; }
        public string Format { get; set; }
        [JsonIgnore]
        public string Pattern { get; set; }
        [JsonIgnore]
        public bool? IsDisabled { get; set; }
        [JsonIgnore]
        public bool? IsReadonly { get; set; }
        [JsonIgnore]
        public int? Order { get; set; }
        [JsonIgnore]
        public bool? IsListItemId { get; internal set; }
        [JsonIgnore]
        public string Display { get; set; }

        public void CopyTo(PropertySettings settings) {
            settings.Title = Title;
            settings.IsRequired = IsRequired;
            settings.Attributes = Attributes;
            settings.Format = Format;
            settings.Order = Order;
            settings.IsListItemId = IsListItemId;
            settings.IsDisabled = IsDisabled;
            settings.IsReadonly = IsReadonly;
            settings.Pattern = Pattern;
            settings.Display = Display;
        }
    }
}