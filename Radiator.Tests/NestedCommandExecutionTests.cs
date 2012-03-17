using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Core.Commanding;
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
                x.For<ICommandValidator<Command>>().Use<CommandValidator>().Ctor<string>("msg").Is("test");
                x.For<ICommandValidator<CommandWithSubCommand>>().Use<ValidatorWithSubCommand>();

                x.For<ICommandExecutor<Command>>().Use<CommandExecutor>().Ctor<string>("msg").Is(subCommandExecMsg);
                x.For<ICommandExecutor<CommandWithSubCommand>>().Use<ExecutorWithSubCommand>();

            });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));
         
            var result = commandService.Execute(new CommandWithSubCommand());

            string expectedMsg = string.Format("Sub command message: {0}", subCommandExecMsg);

            Assert.AreEqual(result.Message, expectedMsg);
        }

    }

   
}