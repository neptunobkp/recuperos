using System;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public sealed class FormatAttribute : Attribute {
        public FormatAttribute(string format) {
            Format = format;
        }

        public string Format { get; }
    }
}