using System;
using FluentValidation;

namespace Recuperos.Aplicacion.Comun
{
    public class SimpleInjectorValidatorFactory : ValidatorFactoryBase
    {
        private readonly IServiceProvider _serviceProvider;

        public SimpleInjectorValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator) _serviceProvider.GetService(validatorType);
        }
    }
}
