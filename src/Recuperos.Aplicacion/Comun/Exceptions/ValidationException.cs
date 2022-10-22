using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using FluentValidation.Results;

namespace Recuperos.Aplicacion.Comun.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new List<string>();
        }

        protected ValidationException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                var propertyFailuresMeda = failures
                    .Where(e => e.PropertyName == propertyName);

                Failures.Add($"{propertyFailuresMeda.First().FormattedMessagePlaceholderValues["PropertyName"]} {string.Join(",", propertyFailures)}");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(nameof(ValidationException), "");
        }

        public List<string> Failures { get; }
    }
}
