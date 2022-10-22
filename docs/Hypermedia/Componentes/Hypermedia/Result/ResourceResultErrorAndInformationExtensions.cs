using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result {
    public static class ResourceResultErrorAndInformationExtensions {
        public static TResult AddError<TResult>(this TResult self, string name, string message) where TResult : ResourceResult {
            self.Errors = Add(() => self.Errors, name, message);

            return self;
        }

        public static TResult AddInformation<TResult>(this TResult self, string name, string message) where TResult : ResourceResult {
            self.Information = Add(() => self.Information, name, message);

            return self;
        }

        private static IDictionary<string, IList<string>> Add(Func<IDictionary<string, IList<string>>> dictionaryAccessor, string name, string message) {
            var dictionary = dictionaryAccessor() ?? new Dictionary<string, IList<string>>();

            if (dictionary.ContainsKey(name)) {
                dictionary[name].Add(message);
            }
            else {
                dictionary.Add(name, new List<string> { message });
            }

            return dictionary;
        }

        public static TResult AddErrors<TResult>(this TResult self, string name, IEnumerable<string> messages) where TResult : ResourceResult {
            messages.ToList().ForEach(m => self.AddError(name, m));
            return self;
        }

        public static TResult AddInformation<TResult>(this TResult self, string name, IEnumerable<string> messages) where TResult : ResourceResult {
            messages.ToList().ForEach(m => self.AddInformation(name, m));
            return self;
        }

        public static TResult AddError<TResult, TProperty>(this TResult self, Expression<Func<TResult, TProperty>> expression, string message) where TResult : ResourceResult {
            var member = (MemberExpression)expression.Body;
            return self.AddError(member.Member.Name, message);
        }

        public static TResult AddInformation<TResult, TProperty>(this TResult self, Expression<Func<TResult, TProperty>> expression, string message) where TResult : ResourceResult {
            var member = (MemberExpression)expression.Body;
            return self.AddInformation(member.Member.Name, message);
        }

        public static TResult AddErrors<TResult, TProperty>(this TResult self, Expression<Func<TResult, TProperty>> expression, IEnumerable<string> messages) where TResult : ResourceResult {
            var member = (MemberExpression)expression.Body;
            return self.AddErrors(member.Member.Name, messages);
        }

        public static TResult AddInformation<TResult, TProperty>(this TResult self, Expression<Func<TResult, TProperty>> expression, IEnumerable<string> messages) where TResult : ResourceResult {
            var member = (MemberExpression)expression.Body;
            return self.AddInformation(member.Member.Name, messages);
        }
    }
}