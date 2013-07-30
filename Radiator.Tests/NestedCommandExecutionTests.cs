using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Radiator.Core;

namespace Radiator.Tests
{
    [TestClass]
    public class NestedCommandExecutionTests : BaseTests
    {
        [TestMethod]
        public void Nested_Command_Is_Called()
        {
            var subExecutorMock = new Mock<EmptyExecutor>();
            
            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand2>>().Use<ExecutorWithSubExecution>();
                x.For<CommandExecutor<SampleCommand>>().Use(subExecutorMock.Object);
            });

            service.Execute(new SampleCommand2());

            subExecutorMock.Verify(executor => 
                executor.ExecuteCommand(It.IsAny<ICommandService>(), It.IsAny<SampleCommand>()),Times.Once());
        }

    }

   
}

