using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Fasterflect;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public class SchemaGenerator {
        public SchemaGenerator() {
            BlackListNames = new List<string> { "Links", "Errors", "Profile", "UrlGenerator", "Information" };
        }

        private IList<string> BlackListNames { get; }

        public SchemaObject<T> Generate<T>(string type = "object") {
            var schemaObject = new SchemaObject<T>(type);

            foreach (var property in typeof(T).Properties()) {
                AddProperty(property, schemaObject);
            }

            return schemaObject;
        }

        public ISchemaObject Generate(object o) {
            return Generate(o.GetType());
        }

        public ISchemaObject Generate(Type type) {
            var schemaObject = new SchemaObject<object>();

            foreach (var property in type.Properties()) {
                AddProperty(property, schemaObject);
            }

            return schemaObject;
        }

        public SchemaGenerator Ignore(string propertyName) {
            BlackListNames.Add(propertyName);
            return this;
        }

        private void AddProperty<T>(PropertyInfo property, ISchemaObject<T> parentObject) {
            var name = property.Name;

            var schemaOptions = GetPropertySettings(property);

            // TODO: Should be made better!
            if (property.PropertyType.Name.StartsWith("Collection")) {
                property = property.PropertyType.GetProperty("Items");
            }

            var type = property.PropertyType.GetJsonTypeName();

            if (BlackListNames.Any(x => x == name)) {
                return;
            }

            if (property.HasAttribute<JsonIgnoreAttribute>() || 
                property.HasAttribute<JsonExtensionDataAttribute>() || 
                property.HasAttribute<SchemaIgnoreAttribute>() ||
                property.HasAttribute<ResourceIdentifierAttribute>()) {
                return;
            }

            switch (type) {
                case "array":
                    var array = SchemaFactory.Array(x => x.Title = schemaOptions.Title ?? name.ToTitleCase());
                    var arrayType = property.PropertyType.GetGenericIEnumerable();
                    parentObject.Property(name, array, schemaOptions.CopyTo);
                    var arraySchemaObject = SchemaFactory.Object();
                    array.Item(arraySchemaObject);
                    foreach (var arrayTypeProperty in arrayType.Properties()) {
                        AddProperty(arrayTypeProperty, arraySchemaObject);
                    }
                    break;
                case "object":
                    var schemaObject = Generate(property.PropertyType);
                    parentObject.Property(name, schemaObject, schemaOptions.CopyTo);
                    break;
                default:
                    parentObject.Property(name, property.PropertyType, schemaOptions.CopyTo);
                    break;
            }
        }

        public PropertySettings GetPropertySettings(PropertyInfo propertyInfo) {
            var settings = new PropertySettings();

            settings.Attribute(propertyInfo.Attribute<ListItemIdAttribute>());
            settings.Attribute(propertyInfo.Attribute<DataTypeAttribute>());
            settings.Attribute(propertyInfo.Attribute<DisplayAttribute>());
            settings.Attribute(propertyInfo.Attribute<MaxLengthAttribute>());
            settings.Attribute(propertyInfo.Attribute<MinLengthAttribute>());
            settings.Attribute(propertyInfo.Attribute<RangeAttribute>());
            settings.Attribute(propertyInfo.Attribute<DisabledAttribute>());
            settings.Attribute(propertyInfo.Attribute<ReadOnlyAttribute>());
            settings.Attribute(propertyInfo.Attribute<RegularExpressionAttribute>());
            settings.Attribute(propertyInfo.Attribute<RequiredAttribute>());
            settings.Attribute(propertyInfo.Attribute<StringLengthAttribute>());
            settings.Attribute(propertyInfo.Attribute<FormatAttribute>() ?? propertyInfo.PropertyType.Attribute<FormatAttribute>());

            return settings;
        }
    }

    public class SchemaGenerator<T> : SchemaGenerator {
        public SchemaGenerator<T> Ignore(Expression<Func<T, object>> expression) {
            var methodCallExpression = (MemberExpression)expression.Body;

            Ignore(methodCallExpression.Member.Name);
            return this;
        }

        public SchemaObject<T> Generate() {
            return Generate<T>();
        }
    }
}