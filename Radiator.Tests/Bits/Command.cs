using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class Command : ICommand
    {
        public int ExampleInt { get; set; }
    }

    public class CommandValidator : ICommandValidator<Command>
    {
        ProcessResult result = new ProcessResult();

        public CommandValidator(string msg)
        {
            result.Message = msg;
            result.Successful = true;
        }

        public ProcessResult ValidateCommand(Command command)
        {
            return result;
        }
    }

    public class CommandExecutor : ICommandExecutor<Command>
    {
        ProcessResult result = new ProcessResult();

        public CommandExecutor(string msg)
        {
            result.Message = msg;
        }

        public ProcessResult ExecuteCommand(ICommandService commandService, Command command)
        {
            return result;
        }

        public ProcessResult OnException<TException>(TException exception, Command command) where TException : Exception
        {
            throw new NotImplementedException();
        }
    }
}