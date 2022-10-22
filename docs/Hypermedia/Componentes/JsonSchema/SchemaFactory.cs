using System;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class SchemaFactory {
        public static ISchemaObject<T> Object<T>(Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();
            optionAction?.Invoke(options);
            return new SchemaObject<T> { Title = options.Title, Format = options.Format };
        }

        public static SchemaObject Object(Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();
            optionAction?.Invoke(options);
            return new SchemaObject { Title = options.Title, Format = options.Format };
        }

        public static ISchemaArray<T> Array<T>(Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();
            optionAction?.Invoke(options);
            return new SchemaArray<T> { Title = options.Title };
        }

        public static SchemaArray Array(Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();
            optionAction?.Invoke(options);
            return new SchemaArray { Title = options.Title };
        }

        public static ISchemaEnum<object> Enumeration(Action<PropertySettings> optionAction = null) {
            var options = new PropertySettings();
            optionAction?.Invoke(options);
            return new SchemaEnum<object> { Title = options.Title };
        }

        public static ISchemaType<object> String(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "string");
        }

        public static ISchemaType<object> Boolean(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "boolean");
        }

        public static ISchemaType<object> Integer(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "integer");
        }

        public static ISchemaType<object> Number(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "number");
        }

        public static ISchemaType<object> TimeRange(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "timerange");
        }

        public static ISchemaType<object> DateTimeRange(Action<PropertySettings> optionAction = null) {
            return CreatePrimitive(optionAction, "datetimerange");
        }

        public static ISchemaType<object> Select(Action<PropertySettings> optionAction = null) {
            var schemaType = CreatePrimitive(optionAction, "string");
            schemaType.Display = DisplayType.Select;
            return schemaType;
        }

        private static ISchemaType<object> CreatePrimitive(Action<PropertySettings> optionAction, string type) {
            var options = new PropertySettings();

            optionAction?.Invoke(options);

            return new SchemaType {
                Title = options.Title,
                Type = type,
                Format = options.Format,
                Order = options.Order,
                Disabled = options.IsDisabled,
                ReadOnly = options.IsReadonly,
                Attributes = options.Attributes
            };
        }
    }

}