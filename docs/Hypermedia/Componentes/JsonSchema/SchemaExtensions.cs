using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Fasterflect;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class SchemaExtensions {
        public static string ToCamelCase(this string value) {
            return value.Substring(0, 1).ToLowerInvariant() + value.Substring(1);
        }

        public static string ToTitleCase(this string str) {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + m.Value[1]);
        }

        public static string GetJsonTypeName(this Type type) {
            type = type.GetUnderlyingNullableType();

            if (type == typeof(string) ||
                type == typeof(Guid) ||
                type.IsEnum ||
                type == typeof(DateTime) ||
                type == typeof(DateTimeOffset) || 
                type == typeof(Select))
                return "string";
            if (type.Implements(typeof(IEnumerable<>)))
                return "array";
            if (type == typeof(bool))
                return "boolean";
            if (type == typeof(int))
                return "integer";
            if (type == typeof(decimal) ||
                type == typeof(double) ||
                type == typeof(float))
                return "number";
            if (type == typeof(TimeRange))
                return "timerange";
            if (type == typeof(DateTimeRange))
                return "datetimerange";

            return "object";
        }

        public static Type GetGenericIEnumerable(this Type type) {
            return type
                .GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GetGenericArguments()[0])
                .First();
        }


        public static Type GetUnderlyingNullableType(this Type type) {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)) {
                return Nullable.GetUnderlyingType(type);
            }
            return type;
        }
    }
}