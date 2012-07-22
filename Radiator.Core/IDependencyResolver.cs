using System.Collections.Generic;
using Radiator.Core.Commanding;

namespace Radiator.Core
{
    public interface IDependencyResolver
    {
        CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command;
        CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command;
    }
}