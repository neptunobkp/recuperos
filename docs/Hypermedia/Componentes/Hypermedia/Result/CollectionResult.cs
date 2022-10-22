using System;
using System.Collections.Generic;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public class CollectionResult : CollectionResult<ResourceResult> {
        public CollectionResult() {}

        public CollectionResult(IEnumerable<ResourceResult> items) : base(items) {}
    }

    public class CollectionResult<T> : ResourceResult where T : ResourceResult {
        public CollectionResult() {
            Items = new List<T>();
        }

        public CollectionResult(IEnumerable<T> items) {
            Items = new List<T>(items);
        }

        public List<T> Items { get; private set; }

        public void Add(T item) {
            if (item == null) {
                throw new ArgumentNullException(nameof(item));
            }
            Items.Add(item);
        }

        public void Add(IEnumerable<T> items) {
            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }
            Items.AddRange(items);
        }

        public void Sort(Comparison<T> comparer) {
            Items.Sort(comparer);
        }

        public override string Profile => "collection";
    }

    public static class CollectionResultExtension {
        public static CollectionResult<T> ToCollectionResult<T>(this IEnumerable<T> list) where T : ResourceResult {
            return list == null ? null : new CollectionResult<T>(list);
        }
    }
}