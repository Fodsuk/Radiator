using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class MockDependencyResolver : IDependencyResolver
    {
        private CommandValidator _validator;
        private CommandExecutor _executor;

        public void SetValidator(CommandValidator validator)
        {
            _validator = validator;
        }

        public void SetExecutor(CommandExecutor executor)
        {
            _executor = executor;
        }


        public ICommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : ICommand
        {
            return (dynamic)_validator;
        }

        public ICommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : ICommand
        {
            return (dynamic)_executor;
        }
    }
}