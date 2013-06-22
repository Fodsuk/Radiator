using System.Collections.Generic;

namespace Radiator.Core
{
    public interface IDependencyResolver
    {
        CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command;
        CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command;
    }
}