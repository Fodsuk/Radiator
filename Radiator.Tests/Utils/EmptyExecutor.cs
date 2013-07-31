using Radiator.Core;

namespace Radiator.Tests.Utils
{
    public class EmptyExecutor : CommandExecutor<SampleCommand>
    {
        public override void ExecuteCommand(ICommandService commandService, SampleCommand command)
        {
        }
    }
}