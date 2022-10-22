using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Recuperos.RestApi.Infraestructura.Componentes.JsonSchema;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    internal static class TemplateExtensions {
        public static Uri ToUrlTemplate(this Uri self, List<ParameterInfo> searchInputs, string rel, SchemaObject schema = null) {
            if (self == null || rel != LinkRel.Search || searchInputs == null) {
                return self;
            }

            var addedInputs = new List<ParameterInfo>();
            var collection = new Dictionary<string, string>();

            var query = self.Query.StartsWith("?") ? self.Query.Substring(1) : self.Query;

            foreach (var token in query.Split(new []{ '&' }, StringSplitOptions.RemoveEmptyEntries)) {
                var searchInput = searchInputs.SingleOrDefault(input => token.ToLower().Contains(input.Name.ToLower()));
                if (searchInput != null) {
                    if (addedInputs.Contains(searchInput)) {
                        continue;
                    }
                    collection.Add(GetQueryStringName(searchInput, schema), null);
                    addedInputs.Add(searchInput);
                }
                else {
                    var subtokens = token.Split('=');
                    collection.Add(subtokens[0], subtokens[1]);
                }
            }

            var missingInputs = searchInputs.Where(input => !addedInputs.Contains(input)).ToList();
            foreach (var missingInput in missingInputs) {
                collection.Add(GetQueryStringName(missingInput, schema), null);
            }

            var basePath = string.IsNullOrEmpty(self.Query) ? self.ToString() : self.ToString().Replace(self.Query, string.Empty).ToLower();
            var builder = new UriBuilder(basePath) {
                Query = string.Join("&", collection.Select(kvp => string.IsNullOrEmpty(kvp.Value) ? kvp.Key : $"{kvp.Key}={kvp.Value}"))
            };

            return builder.Uri;
        }

        private static string FormatSearchInput(string name)
        {
            return "{{" + name + "}}";
        }

        private static string GetQueryStringName(ParameterInfo searchInput, SchemaObject schema) {

            if (schema == null || !typeof(IList).IsAssignableFrom(searchInput.ParameterType)) {
                return FormatSearchInput(searchInput.Name);
            }

            if (!string.Equals(searchInput.Name, schema.Title, StringComparison.OrdinalIgnoreCase)) {
                return FormatSearchInput(searchInput.Name);
            }

            var itemType = searchInput.ParameterType.GetElementType();
            if (itemType == null) {
                return FormatSearchInput(searchInput.Name);
            }

            var typeProperties = itemType.GetProperties();
            var parameters = schema.Properties.SelectMany((_, i) =>
                typeProperties.Select(property => FormatSearchInput($"{searchInput.Name}[{i}].{property.Name}")));
            return string.Join("&", parameters);
        }
    }
}