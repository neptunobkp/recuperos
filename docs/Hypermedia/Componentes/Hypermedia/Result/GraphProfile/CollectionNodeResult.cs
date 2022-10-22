using System.Collections.Generic;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.GraphProfile {
    public class CollectionNodeResult<T> : CollectionResult<T> where T : ResourceResult {
        public CollectionNodeResult() { }

        public CollectionNodeResult(IEnumerable<T> items) : base(items) { }

        [SchemaIgnore]
        public GraphProfileDataResult GraphData { get; set; }
    }
}