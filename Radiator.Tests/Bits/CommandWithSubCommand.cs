using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandWithSubCommand : ICommand
    {
        public string String1 { get; set; }
    }

    public class ValidatorWithSubCommand : ICommandValidator<CommandWithSubCommand>
    {
        public ProcessResult ValidateCommand(CommandWithSubCommand command)
        {
            return new ProcessResult()
                       {
                           Message = "Validation was successful",
                           Successful = true
                       };
        }
    }

    public class ExecutorWithSubCommand : ICommandExecutor<CommandWithSubCommand>
    {
        public ProcessResult ExecuteCommand(ICommandService commandService, CommandWithSubCommand command)
        {
            Command subCommand = new Command()
            {
                ExampleInt = 62
            };

            var subCommandResult = commandService.Execute(subCommand);

            return new ProcessResult()
            {
                Message = string.Format("Sub command message: {0}", subCommandResult.Message),
                Successful = true
            };
        }

        public ProcessResult OnException<TException>(TException exception, CommandWithSubCommand command) where TException : Exception
        {
            throw new NotImplementedException();
        }
    }
}