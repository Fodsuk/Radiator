using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class MockDependencyResolver : IDependencyResolver
    {
        private ExampleCommandValidator _validator;
        private ExampleCommandExecutor _executor;

        public void SetValidator(ExampleCommandValidator validator)
        {
            _validator = validator;
        }

        public void SetExecutor(ExampleCommandExecutor executor)
        {
            _executor = executor;
        }


        public CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command
        {
            return (dynamic)_validator;
        }

        public CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command
        {
            return (dynamic)_executor;
        }
    }
}