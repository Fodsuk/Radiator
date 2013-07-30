using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Core
{
    public abstract class CommandExecutor<TCommand> where TCommand : Command
    {
        public abstract void ExecuteCommand(ICommandService commandService, TCommand command);      
    }
}
