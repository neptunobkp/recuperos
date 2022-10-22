using System.Collections.Generic;
using Newtonsoft.Json;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema.Converters;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    [JsonConverter(typeof(SelectConverter))]
    public class Select {
        public List<SelectItem> Options { get; set; }
        public object Value { get; set; }
        public string Placeholder { get; set; }
        public object ValueOnClear { get; set; }


        public Select(object value) {
            Value = value;
            Options = new List<SelectItem>();
        }

        public Select() {
            Options = new List<SelectItem>();
        }
    }

    public class SelectItem {
        public SelectItem(string title, object value) {
            Title = title;
            Value = value;
        }

        public string Title { get; }
        public object Value { get; }
    }
}