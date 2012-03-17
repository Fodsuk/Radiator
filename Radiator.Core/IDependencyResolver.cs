using System.Collections.Generic;
using Radiator.Core.Commanding;

namespace Radiator.Core
{
    public interface IDependencyResolver
    {
        ICommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : ICommand;
        ICommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : ICommand;
    }
}