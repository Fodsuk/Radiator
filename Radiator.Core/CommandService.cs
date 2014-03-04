using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radiator.Core
{
    public class CommandService : ICommandService
    {
        private CommandServiceConfiguration _config;

        public CommandService(CommandServiceConfiguration config)
        {
            _config = config;
        }

        public ValidationResult<TCommand> Execute<TCommand>(TCommand command) where TCommand : Command
        {
            if(command == null) throw new  ArgumentNullException("command");

            command.SetCommandReference();

            var validator = GetValidator(command);
            var validationResult = new ValidationResult<TCommand>(new ValidationContext<TCommand>());

            if (validator != null)
            {
                validator.ValidateCommand(command);
                validationResult = new ValidationResult<TCommand>(validator.ValidationContext);

                if (validator.ValidationContext.HasErrors)
                    return validationResult;
            }

            ProcessExecutor(command);

            return validationResult;
        }

        public Task<ValidationResult<TCommand>> ExecuteAsync<TCommand>(TCommand command) where TCommand : Command
        {
            return Task<ValidationResult<TCommand>>.Factory.StartNew(() => Execute(command));
        }

        internal void ProcessExecutor<TCommand>(TCommand command) where TCommand : Command
        {
            var executor = _config.GetExecutorForCommand(command);

            if (executor == null)
                throw new Exception(string.Format("No executor found for {0}", command.GetType().FullName));

            executor.ExecuteCommand(this, command);
        }

        internal CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command
        {
            var validator = _config.GetValidatorForCommand(command);

            return validator;
        }
    }

}
