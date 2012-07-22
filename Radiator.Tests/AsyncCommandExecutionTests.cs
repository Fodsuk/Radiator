using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Bits;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class AsyncCommandExecutionTests
    {
        [TestMethod]
        public void Test_Async_CommandExecute_With_Syncronous_Subcommand()
        {
            string subCommandExecMsg = "Sub Command Executed";

            ObjectFactory.Configure(x =>
            {
                x.For<CommandValidator<ExampleCommand>>().Use<ExampleCommandValidator>().Ctor<string>("msg").Is("test");
                x.For<CommandValidator<CommandWithSubCommand>>().Use<ValidatorWithSubCommand>();

                x.For<CommandExecutor<ExampleCommand>>().Use<ExampleCommandExecutor>().Ctor<string>("msg").Is(subCommandExecMsg);
                x.For<CommandExecutor<CommandWithSubCommand>>().Use<ExecutorWithSubCommand>();

            });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));

            var result = commandService.ExecuteAsync(new CommandWithSubCommand());

            string expectedMsg = string.Format("Sub command message: {0}", subCommandExecMsg);

            Assert.AreEqual(result.Result.Message, expectedMsg);
        }

        [TestMethod]
        public void Test_Async_CommandExecute_With_Async_Subcommand()
        {
            string subCommandExecMsg = "Sub Command Executed";

            ObjectFactory.Configure(x =>
            {
                x.For<CommandValidator<ExampleCommand>>().Use<ExampleCommandValidator>().Ctor<string>("msg").Is("test");
                x.For<CommandValidator<CommandWithAsyncSubCommand>>().Use<ValidatorWithAsyncSubCommand>();

                x.For<CommandExecutor<ExampleCommand>>().Use<ExampleCommandExecutor>().Ctor<string>("msg").Is(subCommandExecMsg);
                x.For<CommandExecutor<CommandWithAsyncSubCommand>>().Use<ExecutorWithAsyncSubCommand>();

            });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));

            var result = commandService.ExecuteAsync(new CommandWithAsyncSubCommand());

            string expectedMsg = string.Format("Sub command message: {0}", subCommandExecMsg);

            Assert.AreEqual(result.Result.Message, expectedMsg);
        }
    }
}