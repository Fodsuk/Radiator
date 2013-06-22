/*
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Tests.Bits;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class ResolvingTests
    {
        [TestInitialize]
        public void Init()
        {
            ObjectFactory.ResetDefaults();
        }

        [TestMethod]
        public void Validator_Found()
        {
            MockDependencyResolver resolver = new MockDependencyResolver();
            const string message = "This is the validator you are looking for";
            
            resolver.SetValidator(new ExampleCommandValidator(message));

            Configuration configuration = new Configuration(resolver);

            var validator = configuration.GetValidatorForCommand(new ExampleCommand());

            var result = validator.ValidateCommand(new ExampleCommand());

            Assert.AreEqual(result.Message, message);

        }

        

    }

    [TestClass]
    public class StructureMapTests
    {
        [TestMethod]
        public void Validator_Found()
        {
            ObjectFactory.Configure(
                x => x.For<CommandValidator<ExampleCommand>>().Use<ExampleCommandValidator>().Ctor<string>("msg").Is("test")
            );

            var resolver = new StructureMapDependancyResolver();
            const string message = "test";

            var configuration = new Configuration(resolver);

            var validator = configuration.GetValidatorForCommand(new ExampleCommand());

            var result = validator.ValidateCommand(new ExampleCommand());

            Assert.AreEqual(result.Message, message);

        }

    

    }
}

*/