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
        private Configuration _config;

        public CommandService(Configuration config)
        {
            _config = config;
        }

        public ValidationResult<TCommand> Execute<TCommand>(TCommand command) where TCommand : Command
        {
            var validationResult = ProcessValidator(command);

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

        internal ValidationResult<TCommand> ProcessValidator<TCommand>(TCommand command) where TCommand : Command
        {
            var validator = _config.GetValidatorForCommand(command);

            if (validator == null)
                return new ValidationResult<TCommand>(new ValidationContext<TCommand>());

            var context = validator.ValidationContext;

            return new ValidationResult<TCommand>(context);            
        }
    }

}
