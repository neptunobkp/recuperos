using System;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class SearchInputAttribute : Attribute {
        public SearchInputAttribute(string title = null, bool advanced = false, int order = 1) {
            Advanced = advanced;
            Title = title;
            Order = order;
        }

        public string Title { get; }
        public bool Advanced { get; }
        public int Order { get; }
    }
}