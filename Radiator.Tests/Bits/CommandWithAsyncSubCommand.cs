using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandWithAsyncSubCommand : Command
    {
        public string String1 { get; set; }
    }

    public class ValidatorWithAsyncSubCommand : CommandValidator<CommandWithAsyncSubCommand>
    {
        public override ProcessResult ValidateCommand(CommandWithAsyncSubCommand command)
        {
            return new ProcessResult()
                       {
                           Message = "Validation was successful",
                           Successful = true
                       };
        }
    }

    public class ExecutorWithAsyncSubCommand : CommandExecutor<CommandWithAsyncSubCommand>
    {
        public override ProcessResult ExecuteCommand(ICommandService commandService, CommandWithAsyncSubCommand command)
        {
            var subCommand = new ExampleCommand()
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
    }
}