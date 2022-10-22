using System;
using System.Linq.Expressions;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class SchemaArrayExtensions {
        public static ISchemaArray<T> Item<T>(this ISchemaArray<T> self, ISchemaType type, Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();

            optionAction?.Invoke(options);

            if (options.Title != null) {
                type.Title = options.Title;
            }

            self.Items = type;
            return self;
        }

        public static ISchemaArray<T> Item<T, TProperty>(this ISchemaArray<T> self, Expression<Func<T, TProperty>> expression, Action<PropertySettings> optionAction = null) {
            var member = (MemberExpression)expression.Body;
            var name = member.Member.Name;
            Action<PropertySettings> subAction;
            if (optionAction == null) {
                subAction = option => option.Title = name.ToTitleCase();
            }
            else {
                subAction = option => {
                    optionAction(option);
                    if (option.Title == null)
                        option.Title = name.ToTitleCase();
                };
            }

            var type = typeof(T);

            if (type == typeof(string) || type == typeof(Guid) || type.IsEnum)
                return self.Item(SchemaFactory.String(), subAction);

            if (type == typeof(bool) || type == typeof(bool?))
                return self.Item(SchemaFactory.Boolean(), subAction);

            if (type == typeof(int) || type == typeof(int?))
                return self.Item(SchemaFactory.Integer(), subAction);

            if (type == typeof(decimal) || type == typeof(decimal?) ||
                type == typeof(double) || type == typeof(double?) ||
                type == typeof(float) || type == typeof(float?))
                return self.Item(SchemaFactory.Number(), subAction);

            return self.Item(SchemaFactory.Object<T>(subAction), subAction);
        }
    }
}