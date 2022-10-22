using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class SchemaResult : DocumentResult {
        public SchemaResult(object data) {
            Data = data;
        }

        public override string Profile => "schema";
    }

    public class SchemaResult<T> : SchemaResult {
        public SchemaResult() : base(new SchemaGenerator().Generate<T>()) {
        }

        public static SchemaResult<T> Form() {
            return new SchemaResult<T> {
                Data = new SchemaGenerator().Generate<T>("form")
            };
        }
    }
}