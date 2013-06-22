/*
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Tests.Bits;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class NestedCommandExecutionTests
    {
        [TestMethod]
        public void Nested_Command_Is_Called()
        {
            string subCommandExecMsg = "Sub Command Executed";

            ObjectFactory.Configure(x => {
                x.For<CommandValidator<ExampleCommand>>().Use<ExampleCommandValidator>().Ctor<string>("msg").Is("test");
                x.For<CommandValidator<CommandWithSubCommand>>().Use<ValidatorWithSubCommand>();

                x.For<CommandExecutor<ExampleCommand>>().Use<ExampleCommandExecutor>().Ctor<string>("msg").Is(subCommandExecMsg);
                x.For<CommandExecutor<CommandWithSubCommand>>().Use<ExecutorWithSubCommand>();

            });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));
         
            var result = commandService.Execute(new CommandWithSubCommand());

            string expectedMsg = string.Format("Sub command message: {0}", subCommandExecMsg);

            Assert.AreEqual(result.Message, expectedMsg);
        }

    }

   
}

*/