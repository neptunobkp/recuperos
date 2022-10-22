using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Fasterflect;
using Newtonsoft.Json;

namespace Recuperos.RestApi.Infraestructura.Componentes.JsonSchema {
    public static class PropertySettingsExtensions {
        public static PropertySettings Attribute(this PropertySettings self, string name, object value) {
            self.Attributes[name] = value;
            return self;
        }

        public static PropertySettings Attribute(this PropertySettings self, Attribute attribute)
        {
            if (attribute == null)
            {
                return self;
            }

            if (attribute is DisplayAttribute )
            {
                var display = attribute as DisplayAttribute;
                self.Order = display.GetOrder();
                self.Title = display.Name;
                return self;
            }

            if (attribute is RequiredAttribute )
            {
                self.IsRequired = true;
                return self;
            }
            if (attribute is DisabledAttribute)
            {
                self.IsDisabled = true;
                return self;
            }
            if (attribute is ReadOnlyAttribute )
            {
                var readOnlyType = attribute as ReadOnlyAttribute;
                self.IsReadonly = readOnlyType.IsReadOnly;
                return self;
            }
            if (attribute is DataTypeAttribute )
            {
                var dataType = attribute as DataTypeAttribute;
                self.Format = dataType.CustomDataType ?? Enum.GetName(typeof(DataType), dataType.DataType);
                return self;
            }
            if (attribute is RangeAttribute )
            {
                var range = attribute as RangeAttribute;
                self.Attribute("minimum", range.Minimum);
                self.Attribute("maximum", range.Maximum);
                return self;
            }
            if (attribute is StringLengthAttribute )
            {
                var stringLength = attribute as StringLengthAttribute;
                if (stringLength.MinimumLength > 0)
                {
                    self.Attribute("minLength", stringLength.MinimumLength);
                }

                self.Attribute("maxLength", stringLength.MaximumLength);
                return self;
            }
            if (attribute is MaxLengthAttribute )
            {
                var maxLength = attribute as MaxLengthAttribute;
                self.Attribute("maxItems", maxLength.Length);
                return self;
            }
            if (attribute is MinLengthAttribute )
            {
                var minLength = attribute as MinLengthAttribute;
                self.Attribute("minItems", minLength.Length);
                return self;
            }
            if (attribute is RegularExpressionAttribute )
            {
                var pattern = attribute as RegularExpressionAttribute;
                self.Attribute("pattern", pattern.Pattern);
                return self;
            }
            if (attribute is FormatAttribute )
            {
                var format = attribute as FormatAttribute;
                self.Format = format.Format;
                return self;
            }
            if (attribute is ListItemIdAttribute)
            {
                self.IsListItemId = true;
                return self;
            }
            return self;
        }

        public static PropertySettings Attributes<T, TProperty>(this PropertySettings self, Expression<Func<T, TProperty>> expression, params Type[] attributeTypes) {
            return self.Attributes(expression, (s, a) => Attribute(s, a), attributeTypes);
        }

        public static PropertySettings Attributes<T, TProperty>(this PropertySettings self, Expression<Func<T, TProperty>> expression, Func<PropertySettings, Attribute, PropertySettings> action, params Type[] attributeTypes) {
            var member = (MemberExpression)expression.Body;
            foreach (var attribute in member.Member.Attributes(attributeTypes)) {
                action(self, attribute);
            }
            return self;
        }
    }
}