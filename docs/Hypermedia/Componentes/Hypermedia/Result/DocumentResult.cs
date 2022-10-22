using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class DocumentResult : ResourceResult {
        [JsonExtensionData]
        public IDictionary<string, JToken> Body { get; private set; }

        [JsonIgnore]
        public object Data { get; set; }

        public override string Profile => "document";

        public override void ExecuteResult(ControllerContext context) {
            if (Data != null) {
                var serializer = new JsonSerializer {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                Body = JObject
                    .FromObject(Data, serializer)
                    .Properties()
                    .ToDictionary(p => p.Name, p => p.Value);
            }

            base.ExecuteResult(context);
        }
    }
}