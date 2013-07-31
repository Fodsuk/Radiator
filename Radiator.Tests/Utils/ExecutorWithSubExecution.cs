using Radiator.Core;

namespace Radiator.Tests.Utils
{
    public class ExecutorWithSubExecution : CommandExecutor<SampleCommand2>
    {
        public override void ExecuteCommand(ICommandService commandService, SampleCommand2 command)
        {
            commandService.Execute(new SampleCommand());
        }
    }
}
