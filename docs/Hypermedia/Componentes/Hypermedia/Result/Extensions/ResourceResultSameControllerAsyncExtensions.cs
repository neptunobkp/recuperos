using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultSameControllerAsyncExtensions {
        public static TResult WithAction<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Action, title) : self;
        }
        public static TResult WithPrimaryAction<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.PrimaryAction, title) : self;
        }

        public static TResult WithDescribedBy<TResult>(this TResult self, Expression<Func<Task>> controllerAction, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.DescribedBy) : self;
        }

        public static TResult WithActions<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Actions, title) : self;
        }

        public static TResult WithDelete<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title = "Delete", bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Delete, title) : self;
        }

        public static TResult WithParent<TResult>(this TResult self, Expression<Func<Task>> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Parent);
        }

        public static TResult WithSelf<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Self, title) : self;
        }

        public static TResult WithResourceId<TResult>(this TResult self, Guid resourceId, bool when = true) where TResult : ResourceResult {
            if (when) {
                self.ResourceId = resourceId;
            }
            return self;
        }

        public static TResult WithUpdate<TResult>(this TResult self, Expression<Func<Task>> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Update);
        }

        public static TResult WithUpdate<TResult>(this TResult self, Expression<Func<Task>> controllerAction, bool when, object routeValues) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Update, null, routeValues) : self;
        }

        public static TResult WithSubresource<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Subresource, title) : self;
        }

        public static TResult WithSubmit<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title = "Submit", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Submit, title) : self;
        }

        public static TResult WithSearch<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string title = "Search", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Search, title) : self;
        }
    }
}