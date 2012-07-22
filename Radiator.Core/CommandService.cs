using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radiator.Core.Commanding;

namespace Radiator.Core
{
    public class CommandService : ICommandService
    {
        private Configuration _config;

        public CommandService(Configuration config)
        {
            _config = config;
        }


        public ProcessResult Execute<TCommand>(TCommand command) where TCommand : Command
        {
            var validationResult = ProcessValidator(command);

            if (validationResult.Successful == false) return validationResult;
 
            return  ProcessExecutor(command);
        }

        public Task<ProcessResult> ExecuteAsync<TCommand>(TCommand command) where TCommand : Command
        {
            return Task<ProcessResult>.Factory.StartNew(() => Execute(command));
        }

        
        internal ProcessResult ProcessExecutor<TCommand>(TCommand command) where TCommand : Command
        {
            var executor = _config.GetExecutorForCommand(command);

            if (executor == null)
                throw new Exception(string.Format("No executor found for {0}", command.GetType().FullName));

            try
            {
                return executor.ExecuteCommand(this, command);
            }
            catch (Exception e)
            {
               return executor.OnException(e, command);
            }
        }

        internal ProcessResult ProcessValidator<TCommand>(TCommand command) where TCommand : Command
        {
            var validator = _config.GetValidatorForCommand(command);

            if (validator == null)
                return new ProcessResult() { Successful = true };

            return validator.ValidateCommand(command);
        }
    }

}
