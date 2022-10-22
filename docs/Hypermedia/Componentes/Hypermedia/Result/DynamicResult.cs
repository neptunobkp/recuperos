using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class DynamicResult : ResourceResult {
        [JsonExtensionData]
        public IDictionary<string, JToken> Body { get; private set; }
        public DynamicResult() {
            Body = new Dictionary<string, JToken>();
        }

        public void AddProperty(string key, object value) {
            var contractResolver = new CamelCasePropertyNamesContractResolver();
            var settings = new JsonSerializerSettings {
                ContractResolver = contractResolver
            };

            var serializer = JsonSerializer.Create(settings);

            Body.Add(contractResolver.GetResolvedPropertyName(key), value == null ? null : JToken.FromObject(value, serializer));
        }

        public void AddOrUpdateProperty(string key, object value) {
            var contractResolver = new CamelCasePropertyNamesContractResolver();
            var settings = new JsonSerializerSettings {
                ContractResolver = contractResolver
            };

            var serializer = JsonSerializer.Create(settings);

            var propertyName = contractResolver.GetResolvedPropertyName(key);

            if (!Body.ContainsKey(propertyName)) {
                Body.Add(propertyName, null);
            }

            Body[propertyName] = value == null ? null : JToken.FromObject(value, serializer);
        }
    }
}