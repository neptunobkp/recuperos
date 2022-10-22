using System;
using System.Linq.Expressions;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultSameControllerExtensions {
        public static TResult WithAction<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Action, title) : self;
        }
        public static TResult WithPrimaryAction<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.PrimaryAction, title) : self;
        }

        public static TResult WithDescribedBy<TResult>(this TResult self, Expression<Action> controllerAction, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.DescribedBy) : self;
        }

        public static TResult WithActions<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Actions, title) : self;
        }

        public static TResult WithDelete<TResult>(this TResult self, Expression<Action> controllerAction, string title = "Delete", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Delete, title) : self;
        }

        public static TResult WithParent<TResult>(this TResult self, Expression<Action> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Parent);
        }

        public static TResult WithReorder<TResult>(this TResult self, Expression<Action> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Reorder);
        }

        public static TResult WithSelf<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Self, title) : self;
        }

        public static TResult WithSelf<TResult>(this TResult self, Expression<Action> controllerAction, string title, object routeValues, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Self, title, null, routeValues) : self;
        }

        public static TResult WithSearch<TResult>(this TResult self, Expression<Action> controllerAction, string title = "Search", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Search, title) : self;
        }

        public static TResult WithSearch<TResult>(this TResult self, Expression<Action> controllerAction, SchemaObject schema, string title = "Search", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Search, title, schema: schema) : self;
        }

        public static TResult WithUpdate<TResult>(this TResult self, Expression<Action> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Update);
        }

        public static TResult WithUpdate<TResult>(this TResult self, Expression<Action> controllerAction, bool when) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Update) : self;
        }

        public static TResult WithNavigate<TResult>(this TResult self, Expression<Action> controllerAction, string title, string target, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Navigate, title, target) : self;
        }

        public static TResult WithNavigate<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Navigate, title) : self;
        }

        public static TResult WithSubmit<TResult>(this TResult self, Expression<Action> controllerAction, string title = "Submit", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Submit, title) : self;
        }
    }
}