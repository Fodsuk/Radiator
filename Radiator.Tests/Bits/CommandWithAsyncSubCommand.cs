using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandWithAsyncSubCommand : ICommand
    {
        public string String1 { get; set; }
    }

    public class ValidatorWithAsyncSubCommand : ICommandValidator<CommandWithAsyncSubCommand>
    {
        public ProcessResult ValidateCommand(CommandWithAsyncSubCommand command)
        {
            return new ProcessResult()
                       {
                           Message = "Validation was successful",
                           Successful = true
                       };
        }
    }

    public class ExecutorWithAsyncSubCommand : ICommandExecutor<CommandWithAsyncSubCommand>
    {
        public ProcessResult ExecuteCommand(ICommandService commandService, CommandWithAsyncSubCommand command)
        {
            Command subCommand = new Command()
            {
                ExampleInt = 62
            };

            var subCommandResult = commandService.ExecuteAsync(subCommand);

            return new ProcessResult()
            {
                Message = string.Format("Sub command message: {0}", subCommandResult.Result.Message),
                Successful = true
            };
        }

        public ProcessResult OnException<TException>(TException exception, CommandWithAsyncSubCommand command) where TException : Exception
        {
            throw new NotImplementedException();
        }
    }
}