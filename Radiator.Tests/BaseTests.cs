using System;
using NUnit.Framework;
using Radiator.Core;
using StructureMap;

namespace Radiator.Tests
{
    public class BaseTests
    {
        CommandService service;

        public CommandService BuildCommandService(Action<ConfigurationExpression> serviceConfig)
        {
            var resolver = new StructureMapDependancyResolver();

            ObjectFactory.Configure(serviceConfig);

            var config = new CommandServiceConfiguration(resolver);

            service = new CommandService(config);

            return service;
        }

        [TearDown]
        public void CleanUp()
        {
            ObjectFactory.ResetDefaults();
            service = null;
        }

        public ValidationContext<TCommand> GetExampleValidationContext<TCommand>()
        {
            return new ValidationContext<TCommand>();
        }
       
    }
}