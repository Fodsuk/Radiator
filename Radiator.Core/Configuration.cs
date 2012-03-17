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

        public ICommandValidator<TCommand> GetValidatorForCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _resolver.GetValidator(command);
        }

        public ICommandExecutor<TCommand> GetExecutorForCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            return _resolver.GetExecutor(command);
        }
    }
}
