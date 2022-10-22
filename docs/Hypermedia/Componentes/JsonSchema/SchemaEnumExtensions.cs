using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fasterflect;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class SchemaEnumExtensions {
        public static ISchemaEnum<T> Enum<T>(this ISchemaEnum<T> self, Type @enum) {
            if (@enum.IsEnum) {
                var items = System.Enum.GetValues(@enum).Cast<int>().ToList();
                var names = @enum.GetEnumDescriptionNames().ToList();

                self.Type = @enum.GetCustomAttributes<FlagsAttribute>().Any() ? "enum[]" : "enum";
                self.Items = items.Zip(names, (item, name) => new ListItem(item, name)).ToList();
            }

            return self;
        }

        public static ISchemaEnum<T> Enum<T, TProperty>(this ISchemaEnum<T> self, Expression<Func<T, TProperty>> expression) {
            var member = (MemberExpression)expression.Body;
            var type = member.Member.DeclaringType;

            return self.Enum(type);
        }

        private static IEnumerable<string> GetEnumDescriptionNames(this Type self) {
            return self
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(field => field.Attribute<DescriptionAttribute>()?.Description ?? field.Name.ToCamelCase());
        }
    }
}