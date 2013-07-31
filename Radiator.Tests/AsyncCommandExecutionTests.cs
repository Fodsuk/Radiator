using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Radiator.Core;
using Radiator.Tests.Utils;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class AsyncCommandExecutionTests  : BaseTests
    {
        [TestMethod]
        public void Test_Async_CommandExecute_With_Syncronous_Subcommand()
        {
            var subExecutorMock = new Mock<EmptyExecutor>();

            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand2>>().Use<ExecutorWithSubExecution>();
                x.For<CommandExecutor<SampleCommand>>().Use(subExecutorMock.Object);
            });

            Task<ValidationResult<SampleCommand2>> task  = service.ExecuteAsync(new SampleCommand2());

            task.Wait();
            
            subExecutorMock.Verify(
                executor => executor.ExecuteCommand(It.IsAny<ICommandService>(), It.IsAny<SampleCommand>()),
                Times.Once()
                );
            
        }


        [TestMethod]
        public void Test_Async_CommandExecute_With_Async_Subcommand()
        {
            var subExecutorMock = new Mock<EmptyExecutor>();

            CommandService service = BuildCommandService(x =>
            {
                x.For<CommandExecutor<SampleCommand2>>().Use<ExecutorWithSubAsycExecution>();
                x.For<CommandExecutor<SampleCommand>>().Use(subExecutorMock.Object);
            });

            Task<ValidationResult<SampleCommand2>> task = service.ExecuteAsync(new SampleCommand2());

            task.Wait();

            subExecutorMock.Verify(
                executor => executor.ExecuteCommand(It.IsAny<ICommandService>(), It.IsAny<SampleCommand>()),
                Times.Once()
                );
        }
    }
}
