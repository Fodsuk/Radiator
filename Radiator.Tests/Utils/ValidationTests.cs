using NUnit.Framework;
using Radiator.Core;

namespace Radiator.Tests.Utils
{

    [TestFixture]
    public class ValidationTests : BaseTests
    {

        [Test]
        public void Validate_WithNoErrors_Executes()
        {
            CommandService service = BuildCommandService(x =>
                                        {
                                            x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>();
                                            x.For<CommandValidator<SampleCommand>>().Use<EmptyValidator>();
                                        });

            Assert.DoesNotThrow(() => service.Execute(new SampleCommand()));

        }

        [Test]
        public void Validate_WithPropertyError_FailsWithCorrectError()
        {
            CommandService service = BuildCommandService(x =>
                        {
                            x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>();
                            x.For<CommandValidator<SampleCommand>>().Use<ValidatorWithPropertyError>();
                        });

            var result = service.Execute(new SampleCommand());

            Assert.IsTrue(result.HasErrors);
            Assert.IsTrue(result.HasError<Error1>(cmd => cmd.Age));

        }

        [Test]
        public void Validate_WithGeneralError_FailsWithCorrectError()
        {
            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>();
                x.For<CommandValidator<SampleCommand>>().Use<ValidatorWithGeneralError>();
            });

            var result = service.Execute(new SampleCommand());

            Assert.IsTrue(result.HasErrors);
            Assert.IsTrue(result.HasError<Error2>());
        }

        [Test]
        public void Validate_WithMultiplePropertiesThatHaveAnError_FailsWithCorrectErrors()
        {
            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>();
                x.For<CommandValidator<SampleCommand>>().Use<ValidatorWithMultiplePropertiesThatHaveAnError>();
            });

            var result = service.Execute(new SampleCommand());

            Assert.IsTrue(result.HasErrors);
            Assert.IsTrue(result.HasError<Error1>(cmd => cmd.Age));
            Assert.IsTrue(result.HasError<Error2>(cmd => cmd.FirstName));
        }

        [Test]
        public void Validate_WithMultipleGeneralErrors_FailsWithCorrectErrors()
        {
            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>();
                x.For<CommandValidator<SampleCommand>>().Use<ValidatorWithMultipleGeneralErrors>();
            });

            var result = service.Execute(new SampleCommand());

            Assert.IsTrue(result.HasErrors);
            Assert.IsTrue(result.HasError<Error1>());
            Assert.IsTrue(result.HasError<Error2>());
        }

    }
}
