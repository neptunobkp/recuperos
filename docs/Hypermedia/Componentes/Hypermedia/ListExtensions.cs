using System.Collections;
using System.Collections.Generic;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia {
    public static class ListExtensions {
        public static IReadOnlyCollection<KeyValuePair<string, object>> ToPropertiesDictionary(this IList enumerable, string name = null) {
            var itemType = enumerable?.GetType().GetElementType();
            if (itemType == null) {
                return new Dictionary<string, object>();
            }

            var properties = itemType.GetProperties();
            var parameters = new Dictionary<string, object>();

            var i = 0;
            foreach (var item in enumerable) {
                foreach (var property in properties) {
                    parameters.Add($"{name}[{i}].{property.Name}", property.GetValue(item));
                }

                i++;
            }

            return parameters;
        }
    }
}