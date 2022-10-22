using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class ResourceResultExtensions {
        public static T AutoMap<T>(this T self, object source) {
            var leftSideProperties = self.GetType().GetProperties().Where(x => IsValueType(x.PropertyType) && x.CanWrite).ToList();
            var rightSideProperties = source.GetType().GetProperties().Where(x => IsValueType(x.PropertyType)).ToList();

            foreach (var property in leftSideProperties) {
                var match = rightSideProperties.SingleOrDefault(x => x.Name == property.Name && x.PropertyType == property.PropertyType);
                if (match == null) continue;
                property.SetValue(self, match.GetValue(source));
            }

            return self;
        }

        private static bool IsValueType(Type type) {
            return (type.IsValueType || (Nullable.GetUnderlyingType(type) != null && Nullable.GetUnderlyingType(type).IsValueType)) || type == typeof(string);
        }

        internal static TResult AddLink<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string rel, string title = null, object routeValues = null, Guid? resourceId = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction, routeValues), rel, title, searchInputs: GetSearchInputs(controllerAction, rel), resourceId: resourceId);
        }

        internal static TResult AddLink<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string rel, string title = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction), rel, title, searchInputs: GetSearchInputs(controllerAction, rel));
        }

        internal static TResult AddLink<TResult, TController>(this TResult self, Expression<Action<TController>> controllerAction, string rel, IEnumerable<int> disallowedIndexes, string title = null, string target = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction), rel, title, target, disallowedIndexes, GetSearchInputs(controllerAction, rel));
        }

        internal static TResult AddLink<TResult>(this TResult self, Expression<Func<Task>> controllerAction, string rel, string title = null, object routeValues = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction, routeValues), rel, title, searchInputs: GetSearchInputs(controllerAction, rel));
        }

        internal static TResult AddLink<TResult>(this TResult self, Expression<Action> controllerAction, string rel, string title = null, string target = null, object routeValues = null, SchemaObject schema = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction, routeValues), rel, title, target, searchInputs: GetSearchInputs(controllerAction, rel, false), schema: schema);
        }

        internal static TResult AddLink<TResult, TController>(this TResult self, Expression<Func<TController, Task>> controllerAction, string rel, string title = null, string target = null, object routeValues = null) where TResult : ResourceResult {
            return !controllerAction.IsAuthorizedToExecute() ?
                self :
                self.AddLink(x => x.Generate(controllerAction, routeValues), rel, title, target);
        }

        internal static TResult AddLink<TResult>(this TResult self, Func<TypedUrlGenerator, Uri> resolveUrl, string rel, string title = null, string target = null, IEnumerable<int> disallowedIndexes = null, List<ParameterInfo> searchInputs = null, Guid? resourceId = null, SchemaObject schema = null) where TResult : ResourceResult {
            return self.AddLink(new Link {
                Href = resolveUrl(TypedUrlGenerator.Current).ToUrlTemplate(searchInputs, rel, schema),
                Rel = rel.ToCamelCase(),
                Title = title,
                Target = target,
                Template = schema ?? GenerateUrlTemplateSchema(searchInputs, rel),
                DisallowedIndexes = (disallowedIndexes == null || !disallowedIndexes.Any()) ? null : string.Join(",", disallowedIndexes.ToArray()),
                ResourceId = resourceId
            });
        }

        private static SchemaObject GenerateUrlTemplateSchema(IEnumerable<ParameterInfo> searchInputs, string rel) {
            if (rel != LinkRel.Search || searchInputs == null) {
                return null;
            }

            var schemaObject = SchemaFactory.Object();
            foreach (var template in searchInputs) {
                var attribute = template.GetCustomAttribute<SearchInputAttribute>();
                schemaObject.Property(template.Name, template.ParameterType, x => {
                    x.Title = attribute?.Title;
                    x.Order = attribute?.Order;
                    x.Display = attribute != null && attribute.Advanced ? DisplayType.Advanced : null;
                });
            }
            return schemaObject;
        }

        private static TResult AddLink<TResult>(this TResult self, Link link) where TResult : ResourceResult {
            self.Links.Add(link);
            return self;
        }

        private static string ToCamelCase(this string value) {
            return value.Substring(0, 1).ToLowerInvariant() + value.Substring(1);
        }

        private static List<ParameterInfo> GetSearchInputs(Expression<Action> controllerAction, string rel, bool useAttribute = true) {
            return GetSearchInputs((MethodCallExpression)controllerAction.Body, rel, useAttribute);
        }
        private static List<ParameterInfo> GetSearchInputs(Expression<Func<Task>> controllerAction, string rel, bool useAttribute = true) {
            return GetSearchInputs((MethodCallExpression)controllerAction.Body, rel, useAttribute);
        }

        private static List<ParameterInfo> GetSearchInputs<TController>(Expression<Action<TController>> controllerAction, string rel, bool useAttribute = true) {
            return GetSearchInputs((MethodCallExpression)controllerAction.Body, rel, useAttribute);
        }

        private static List<ParameterInfo> GetSearchInputs<TController>(Expression<Func<TController, Task>> controllerAction, string rel, bool useAttribute = true) {
            return GetSearchInputs((MethodCallExpression)controllerAction.Body, rel, useAttribute);
        }

        private static List<ParameterInfo> GetSearchInputs(MethodCallExpression methodCallExpression, string rel, bool useAttribute) {
            return rel == LinkRel.Search ? methodCallExpression
                .Method
                .GetParameters()
                .Where(x => !useAttribute || x.GetCustomAttributes<SearchInputAttribute>().Any())
                .ToList() : null;
        }
    }
}