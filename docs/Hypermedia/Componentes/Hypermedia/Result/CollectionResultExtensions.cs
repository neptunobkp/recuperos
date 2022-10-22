using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public static class CollectionResultExtensions {
        public static TCollectionResult WithItem<TCollectionResult, T>(this TCollectionResult self, Uri selfHref, string selfTitle) where TCollectionResult : CollectionResult<T> where T : ResourceResult, new() {
            self.Items.Add(new T().WithSelf(selfHref, selfTitle));
            return self;
        }

        public static TCollectionResult WithItem<TCollectionResult, TController>(this TCollectionResult self, Expression<Func<TController, Task>> controllerAction, string selfTitle) where TCollectionResult : CollectionResult<ResourceResult> {
            return self.WithItem<TCollectionResult, ResourceResult, TController>(controllerAction, selfTitle);
        }

        public static CollectionResult<T> WithItem<T, TController>(this CollectionResult<T> self, Expression<Func<TController, Task>> controllerAction, string selfTitle) where T : ResourceResult, new() {
            return self.WithItem<CollectionResult<T>, T, TController>(controllerAction, selfTitle);
        }

        public static CollectionResult<ResourceResult> WithItem<TController>(this CollectionResult<ResourceResult> self, Expression<Func<TController, Task>> controllerAction, string selfTitle) {
            return self.WithItem<CollectionResult<ResourceResult>, ResourceResult, TController>(controllerAction, selfTitle);
        }

        public static TCollectionResult WithItem<TCollectionResult, T, TController>(this TCollectionResult self, Expression<Func<TController, Task>> controllerAction, string selfTitle) where TCollectionResult : CollectionResult<T> where T : ResourceResult, new() {
            self.Items.Add(new T().WithSelf(controllerAction, selfTitle));
            return self;
        }

        public static TCollectionResult WithItem<TCollectionResult, T, TController>(this TCollectionResult self, Expression<Action<TController>> controllerAction, string selfTitle) where TCollectionResult : CollectionResult<T> where T : ResourceResult, new() {
            self.Items.Add(new T().WithSelf(controllerAction, selfTitle));
            return self;
        }

        public static CollectionResult<T> WithItem<T, TController>(this CollectionResult<T> self, Expression<Action<TController>> controllerAction, string selfTitle) where T : ResourceResult, new() {
            self.Items.Add(new T().WithSelf(controllerAction, selfTitle));
            return self;
        }

        public static CollectionResult<ResourceResult> WithItem<TController>(this CollectionResult<ResourceResult> self, Expression<Action<TController>> controllerAction, string selfTitle) {
            return self.WithItem<ResourceResult, TController>(controllerAction, selfTitle);
        }

        public static TCollectionResult WithItem<TCollectionResult, T>(this TCollectionResult self, Expression<Action> controllerAction, string selfTitle) where TCollectionResult : CollectionResult<T> where T : ResourceResult, new() {
            self.Items.Add(new T().WithSelf(controllerAction, selfTitle));
            return self;
        }

        public static TCollectionResult WithItems<TCollectionResult, T>(this TCollectionResult self, IEnumerable<T> items) where TCollectionResult : CollectionResult<T> where T : ResourceResult, new() {
            self.Items.AddRange(items);
            return self;
        }
    }
}