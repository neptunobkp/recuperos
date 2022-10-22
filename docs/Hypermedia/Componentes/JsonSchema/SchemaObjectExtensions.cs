using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fasterflect;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class SchemaObjectExtensions {
        public static ISchemaObject<T> Property<T>(this ISchemaObject<T> self, string name, Type type, Action<PropertySettings> optionAction = null) {
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

            type = type.GetUnderlyingNullableType();

            if (type == typeof(string) ||
                type == typeof(Guid))
                return self.Property(name, SchemaFactory.String(), subAction);

            if (type == typeof(DateTime)) {
                return self.Property(name, SchemaFactory.String(options => {
                    options.Format = PropertyFormatType.Date;
                }), subAction);
            }

            if (type == typeof(DateTimeOffset)) {
                return self.Property(name, SchemaFactory.String(options => {
                    options.Format = PropertyFormatType.DateTime;
                }), subAction);
            }

            if (type == typeof(bool))
                return self.Property(name, SchemaFactory.Boolean(), subAction);

            if (type == typeof(int))
                return self.Property(name, SchemaFactory.Integer(), subAction);

            if (type == typeof(decimal) ||
                type == typeof(double) ||
                type == typeof(float))
                return self.Property(name, SchemaFactory.Number(), subAction);

            if (type == typeof(TimeRange))
                return self.Property(name, SchemaFactory.TimeRange(), subAction);

            if (type == typeof(DateTimeRange))
                return self.Property(name, SchemaFactory.DateTimeRange(), subAction);

            if (type.IsEnum)
                return self.Property(name, SchemaFactory.Enumeration().Enum(type), subAction);

            if (type == typeof(Select)) {
                return self.Property(name, SchemaFactory.Select(), subAction);
            }

            if (IsEnumerable(type))
                return self.Property(name, SchemaFactory.Array<T>(), subAction);

            return self.Property(name, SchemaFactory.Object<T>(), subAction);
        }

        public static ISchemaObject<T> Property<T>(this ISchemaObject<T> self, string name, ISchemaType type, Action<PropertySettings> optionAction = null) {
            if (self.Properties == null) {
                self.Properties = new Dictionary<string, SchemaType>();
            }

            AddProperty(self, name, (SchemaType)type);

            var options = new PropertySettings();
            optionAction?.Invoke(options);

            if (options.IsRequired) {
                if (self.Required == null) {
                    self.Required = new List<string>();
                }
                self.Required.Add(name.ToCamelCase());
            }
            else {
                if (self.Required != null) {
                    self.Required.Remove(name);
                    if (self.Required.Count == 0)
                        self.Required = null;
                }
            }

            if (options.IsDisabled.HasValue)
                type.Disabled = options.IsDisabled;

            if (options.IsListItemId.HasValue)
                type.ListItemId = options.IsListItemId;

            if (options.IsReadonly.HasValue)
                type.ReadOnly = options.IsReadonly;

            options.Attributes.ToList().ForEach(kvp => type.Attributes[kvp.Key] = kvp.Value);

            if (options.Order.HasValue)
                type.Order = options.Order;

            if (options.Format != null)
                type.Format = options.Format;

            if (options.Title != null) {
                type.Title = options.Title;
            }
            else if (type.Title == null) {
                type.Title = name.ToTitleCase();
            }

            if (options.Display != null)
                type.Display = options.Display;

            return self;
        }

        public static ISchemaObject<T> Property<T, TProperty>(this ISchemaObject<T> self, Expression<Func<T, TProperty>> expression, Action<PropertySettings> optionAction = null) {
            var member = (MemberExpression)expression.Body;
            var name = member.Member.Name;
            return self.Property(name, typeof(TProperty), AddAttributes(member.Member, optionAction));
        }

        public static ISchemaObject<T> Property<T, TProperty>(this ISchemaObject<T> self, Expression<Func<T, TProperty>> expression, ISchemaType type, Action<PropertySettings> optionAction = null) {
            var member = (MemberExpression)expression.Body;
            return self.Property(member.Member.Name, type, AddAttributes(member.Member, optionAction));
        }

        private static Action<PropertySettings> AddAttributes(MemberInfo member, Action<PropertySettings> optionAction = null) {

            Action<PropertySettings> subAction;
            if (optionAction == null) {
                subAction = option => {
                    foreach (var attribute in member.Attributes())
                        option.Attribute(attribute);
                };
            }
            else {
                subAction = option => {
                    optionAction(option);
                    foreach (var attribute in member.Attributes())
                        option.Attribute(attribute);
                };
            }
            return subAction;
        }

        private static bool IsEnumerable(Type type) {
            return type
                .GetInterfaces()
                .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GetGenericArguments()[0])
                .FirstOrDefault() != null;
        }

        private static void AddProperty<T>(ISchemaObject<T> self, string name, SchemaType type) {
            var i = 1;
            var updatedName = name;

            while (self.Properties.ContainsKey(updatedName))
                updatedName = name + i;

            self.Properties.Add(updatedName, type);
        }
    }
}