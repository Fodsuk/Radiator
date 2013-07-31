using Radiator.Core;

namespace Radiator.Tests.Utils
{
    public class ExecutorWithSubAsycExecution : CommandExecutor<SampleCommand2>
    {
        public override void ExecuteCommand(ICommandService commandService, SampleCommand2 command)
        {
            var task = commandService.ExecuteAsync(new SampleCommand());
            task.Wait();
        }
    }
}