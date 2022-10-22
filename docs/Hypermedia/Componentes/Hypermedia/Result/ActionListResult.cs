using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class ActionListResult : DocumentResult {
        public ActionListResult() {
            Actions = new CollectionResult<ResourceResult>();
        }

        public ActionListResult(CollectionResult<ResourceResult> actions) {
            Actions = actions;
        }

        public CollectionResult<ResourceResult> Actions { get; }

        public ActionListResult WithActionItem(Expression<Action> actionFunc, string title, bool when = true) {
            if (when) {
                Actions.Add(new ResourceResult()
                    .WithPrimaryAction(actionFunc, title));
            }

            return this;
        }

        public ActionListResult WithActionItem(Expression<Func<Task>> actionFunc, string title, bool when = true) {
            if (when) {
                Actions.Add(new ResourceResult()
                    .WithPrimaryAction(actionFunc, title));
            }

            return this;
        }

        public ActionListResult WithActionItem<TController>(Expression<Action<TController>> actionFunc, string title, bool when = true) {
            if (when) {
                Actions.Add(new ResourceResult()
                    .WithPrimaryAction(actionFunc, title));
            }

            return this;
        }

        public ActionListResult WithActionItem<TController>(Expression<Func<TController, Task>> actionFunc, string title, bool when = true) {
            if (when) {
                Actions.Add(new ResourceResult()
                    .WithPrimaryAction(actionFunc, title));
            }

            return this;
        }

        public ActionListResult SortActions() {
            Actions.Sort((a, b) => {
                var first = a.Links.FirstOrDefault();
                var second = b.Links.FirstOrDefault();
                return StringComparer.InvariantCultureIgnoreCase.Compare(first?.Title, second?.Title);
            });
            return this;
        }
    }
}