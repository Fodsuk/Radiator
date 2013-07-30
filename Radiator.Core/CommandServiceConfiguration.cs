using System;
using System.Collections.Generic;
using System.Text;

namespace Radiator.Core
{
    public class CommandServiceConfiguration
    {
        private readonly ICommandDependencyResolver _resolver;

        public CommandServiceConfiguration(ICommandDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public CommandValidator<TCommand> GetValidatorForCommand<TCommand>(TCommand command) where TCommand : Command
        {
            return _resolver.GetValidator(command);
        }

        public CommandExecutor<TCommand> GetExecutorForCommand<TCommand>(TCommand command) where TCommand : Command
        {
            return _resolver.GetExecutor(command);
        }
    }
}
