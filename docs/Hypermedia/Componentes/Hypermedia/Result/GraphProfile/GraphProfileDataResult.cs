namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.GraphProfile {
    public class GraphProfileDataResult : ResourceResult {
        public GraphProfileDataResult() {
            Edges = new CollectionResult<EdgeResult>();
        }

        public CollectionResult<EdgeResult> Edges { get; set; }
    }
}