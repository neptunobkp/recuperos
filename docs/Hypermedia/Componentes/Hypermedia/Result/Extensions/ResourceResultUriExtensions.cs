using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultUriExtensions {
        private static TResult AddLink<TResult>(this TResult self, Uri href, string rel, string title = null, string target = null) where TResult : ResourceResult {
            return self.AddLink(x => href, rel, title, target);
        }

        public static TResult WithParent<TResult>(this TResult self, Uri href) where TResult : ResourceResult {
            return self.AddLink(href, LinkRel.Parent);
        }

        public static TResult WithEntryPoint<TResult>(this TResult self, Uri href) where TResult : ResourceResult {
            return self.AddLink(href, LinkRel.EntryPoint);
        }

        public static TResult WithEntryPointRoute<TResult>(this TResult self, Controller controller) where TResult : ResourceResult {
            return self.WithEntryPoint(GetRootUri(controller));
        }

        public static TResult WithSelf<TResult>(this TResult self, Uri href, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Self, title) : self;
        }

        public static TResult WithSelf<TResult>(this TResult self, Uri href, string title, string target, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Self, title, target) : self;
        }

        public static TResult WithPrimaryAction<TResult>(this TResult self, Uri href, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.PrimaryAction, title) : self;
        }

        public static TResult WithAction<TResult>(this TResult self, Uri href, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Action, title) : self;
        }

        public static TResult WithUpdate<TResult>(this TResult self, Uri href, string title = null) where TResult : ResourceResult {
            return self.AddLink(href, LinkRel.Update, title);
        }

        public static TResult WithDelete<TResult>(this TResult self, Uri href, string title = "Delete", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Delete, title) : self;
        }

        public static TResult WithSubresource<TResult>(this TResult self, Uri href, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Subresource, title) : self;
        }

        public static TResult WithNavigate<TResult>(this TResult self, Uri href, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Navigate, title) : self;
        }

        public static TResult WithNavigate<TResult>(this TResult self, Uri href, string title, string target, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(href, LinkRel.Navigate, title, target) : self;
        }

        public static TResult WithNavigate<TResult>(this TResult self, NavigationUri navigationUri, bool when = true) where TResult : ResourceResult {
            return self.WithNavigate(navigationUri.Uri, navigationUri.Title, when);
        }

        private static Uri GetRootUri(Controller controller) {
            if (controller == null) {
                throw new ArgumentNullException(nameof(controller));
            }

            var requestUrl = controller.Request?.Url;
            if (requestUrl == null) {
                throw new ArgumentException("Controller is missing request url");
            }

            var currentRoute = controller.RouteData.Values;
            var protocol = requestUrl.Scheme;
            var hostname = requestUrl.Host;
            var routeValues = new RouteValueDictionary {
                ["tenant"] = currentRoute["tenant"],
                ["application"] = currentRoute["application"],
                ["changeset"] = currentRoute["changeset"]
            };

            var route = controller.Url.RouteUrl("DesignerRoot", routeValues, protocol, hostname);
            if (string.IsNullOrEmpty(route)) {
                throw new Exception("route could not be generated");
            }

            return new Uri(route);
        }
    }
}