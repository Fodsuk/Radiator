using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Core
{
    public abstract class CommandExecutor<TCommand> : BaseCommandExecutor<TCommand> where TCommand : Command
    {
    }
}
