using System.Collections.Generic;
using System.Dynamic;

namespace Recuperos.RestApi.Infraestructura.Componentes.Hypermedia.Result.Extensions {
    public static class DynamicResultExtendedDataExtensions {
        private const string ExtendedDataPropertyName = "extendedData";

        public static DynamicResult AddExtendedDataProperty(this DynamicResult dynamicResult, string key, object value, bool when = true) {
            if (!when) {
                return dynamicResult;
            }

            var extendedData = (IDictionary<string, object>)GetExtendedData(dynamicResult);
            extendedData.Add(key, value);
            dynamicResult.AddOrUpdateProperty("extendedData", extendedData);
            return dynamicResult;
        }

        public static DynamicResult SetExtendedData(this DynamicResult dynamicResult, object value) {
            dynamicResult.AddOrUpdateProperty("extendedData", value);
            return dynamicResult;
        }

        private static ExpandoObject GetExtendedData(this DynamicResult dynamicResult) {
            if (!dynamicResult.Body.ContainsKey(ExtendedDataPropertyName)) {
                return new ExpandoObject();
            }

            return dynamicResult.Body[ExtendedDataPropertyName].ToObject<ExpandoObject>();
        }
    }
}