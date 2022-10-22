using System;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia {
    public class NavigationUri {
        public Uri Uri { get; }
        public string Title { get; private set; }

        public NavigationUri(Uri uri, string title) {
            Uri = uri;
            Title = title;
        }

        public NavigationUri WithTitle(string title) {
            Title = title;
            return this;
        }
    }
}
