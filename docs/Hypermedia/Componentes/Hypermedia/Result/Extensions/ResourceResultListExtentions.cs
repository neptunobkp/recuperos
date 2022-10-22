using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultListExtentions {
        public static List<ResourceResult> AddIfAuthorized<TController>(this List<ResourceResult> self, Expression<Func<TController, Task>> controllerAction, string title) {
            if (!controllerAction.IsAuthorizedToExecute()) {
                return self;
            }
            self.Add(new ResourceResult().WithSelf(controllerAction, title));
            return self;
        }

        public static List<ResourceResult> AddIfAuthorized<TController>(this List<ResourceResult> self, Expression<Action<TController>> controllerAction, string title) {
            if (!controllerAction.IsAuthorizedToExecute()) {
                return self;
            }
            self.Add(new ResourceResult().WithSelf(controllerAction, title));
            return self;
        }

        public static List<ResourceResult> Add<TController>(this List<ResourceResult> self, Expression<Action<TController>> controllerAction, string title, bool when) {
            if (when) {
                self.Add(new ResourceResult().WithSelf(controllerAction, title));
            }

            return self;
        }
    }
}