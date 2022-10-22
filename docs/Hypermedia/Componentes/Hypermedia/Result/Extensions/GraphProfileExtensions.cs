using System;
using System.Linq.Expressions;
using Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.GraphProfile;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class GraphProfileExtensions {
        public static TResult WithSourceNode<TResult>(this TResult self, Expression<Action> controllerAction) where TResult : EdgeResult {
            return self.AddLink(controllerAction, "source-node");
        }
        public static TResult WithTargetNode<TResult>(this TResult self, Expression<Action> controllerAction) where TResult : EdgeResult {
            return self.AddLink(controllerAction, "target-node");
        }
    }
}