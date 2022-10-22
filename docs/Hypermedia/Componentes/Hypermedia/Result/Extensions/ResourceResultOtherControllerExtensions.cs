using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultOtherControllerExtensions {
        public static TResult WithAction<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Action, title) : self;
        }

        public static TResult WithDelete<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title = "Delete", bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Delete, title) : self;
        }

        public static TResult WithEntryPoint<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.EntryPoint);
        }

        public static TResult WithParent<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Parent) : self;
        }

        public static TResult WithActions<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Actions, title) : self;
        }

        public static TResult WithPrimaryAction<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.PrimaryAction, title) : self;
        }

   
        public static TResult WithReorder<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, IEnumerable<int> disallowedIndexes = null) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Reorder, disallowedIndexes);
        }

        public static TResult WithSelf<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true, object routeValues = null) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Self, title) : self;
        }

        public static TResult WithNavigate<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Navigate, title) : self;
        }

        public static TResult WithUpdate<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction) where TResult : ResourceResult {
            return self.AddLink(controllerAction, LinkRel.Update);
        }

        public static TResult WithSubresource<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Subresource, title) : self;
        }

        public static TResult WithSubresource<TResult>(this TResult self, Expression<Action> controllerAction, string title, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.Subresource, title) : self;
        }

        public static TResult WithDescribedBy<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, bool when = true) where TResult : ResourceResult {
            return when ? self.AddLink(controllerAction, LinkRel.DescribedBy) : self;
        }
    }
}