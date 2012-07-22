using System;
using System.Collections.Generic;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Core
{
    public class Configuration
    {
        private IDependencyResolver _resolver;

        public Configuration(IDependencyResolver resolver)
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
