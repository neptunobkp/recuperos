using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public interface ISchemaEnum : ISchemaType {
        IList<ListItem> Items { get; set; }
        void Add(ListItem listItem);
        void Add(object key, string display);
        void Remove(int key);
    }

    public interface ISchemaEnum<out T> : ISchemaType<T>, ISchemaEnum {
    }

    public class SchemaEnum<T> : SchemaType, ISchemaEnum<T> {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<object> Enum => Items.Select(x => x.Key);
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<string> EnumNames => Items.Select(x => x.DisplayText);
        [JsonIgnore]
        public IList<ListItem> Items { get; set; }
        public override string Type { get; set; }

        public SchemaEnum() {
            Items = new List<ListItem>();
            Type = "enum";
        }

        public void Add(ListItem listItem) {
            if (listItem == null) {
                throw new ArgumentNullException(nameof(listItem));
            }

            Items.Add(listItem);
        }

        public void Add(object key, string display) {
            Items.Add(new ListItem(key, display));
        }

        public void AddFirst(object key, string display) {
            Items.Insert(0, new ListItem(key, display));
        }

        public void Remove(int key) {
            var itemToRemove = Items.SingleOrDefault(item => Convert.ToInt32(item.Key) == key);
            if (itemToRemove != null) {
                Items.Remove(itemToRemove);
            }
        }
    }

    public class SchemaEnum : SchemaEnum<object> {
    }
}