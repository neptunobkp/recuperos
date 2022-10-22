using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultOtherControllerAsyncExtensions {
        public static TResult WithAction<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Action, title, routeValues) : self;
        }

        public static TResult WithDelete<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title = "Delete", bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Delete, title, routeValues) : self;
        }

        public static TResult WithParent<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, object routeValues = null, Guid? resourceId = null) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Parent, null, routeValues, resourceId);
        }
        public static TResult WithPrimaryAction<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.PrimaryAction, title, routeValues) : self;
        }

        public static TResult WithSubresource<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Subresource, title, routeValues) : self;
        }

        public static TResult WithSelf<TResult>(this TResult self, string namedRoute, string title, RouteValueDictionary routeValues, bool when = true) where TResult : ResourceResult {
            if (!when) {
                return self;
            }

            self.Links.Add(new Link() {
                Href = TypedUrlGenerator.Current.Generate(namedRoute, routeValues),
                Rel = LinkRel.Self,
                Title = title
                });

            return self;
        }

        public static TResult WithSelf<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Self, title, routeValues) : self;
        }

        public static TResult WithUpdate<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Update, null, routeValues);
        }

        public static TResult WithNavigate<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string title, string target = null, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Navigate, title, target) : self;
        }
    }
}