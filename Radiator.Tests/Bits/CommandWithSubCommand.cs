using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandWithSubCommand : Command
    {
        public string String1 { get; set; }
    }

    public class ValidatorWithSubCommand : CommandValidator<CommandWithSubCommand>
    {
        public override ProcessResult ValidateCommand(CommandWithSubCommand command)
        {
            return new ProcessResult()
                       {
                           Message = "Validation was successful",
                           Successful = true
                       };
        }
    }

    public class ExecutorWithSubCommand : CommandExecutor<CommandWithSubCommand>
    {
        public override ProcessResult ExecuteCommand(ICommandService commandService, CommandWithSubCommand command)
        {
            var subCommand = new ExampleCommand()
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
    }
}