using System;
using System.Threading.Tasks;

namespace Radiator.Core
{
    public abstract class BaseCommandExecutor<TCommand> where TCommand : Command
    {
        public abstract void ExecuteCommand(ICommandService commandService, TCommand command);       
    }
}
