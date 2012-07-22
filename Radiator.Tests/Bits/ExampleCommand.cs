using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class ExampleCommand : Command
    {
        public int ExampleInt { get; set; }
    }

    public class ExampleCommandExecutor : CommandExecutor<ExampleCommand>
    {
        ProcessResult result = new ProcessResult();

        public ExampleCommandExecutor(string msg)
        {
            result.Message = msg;
        }

        public override ProcessResult ExecuteCommand(ICommandService commandService, ExampleCommand command)
        {
            return result;
        }

    }

    public class ExampleCommandValidator : CommandValidator<ExampleCommand>
    {
        ProcessResult result = new ProcessResult();

        public ExampleCommandValidator(string msg)
        {
            result.Message = msg;
            result.Successful = true;
        }

        public override ProcessResult ValidateCommand(ExampleCommand command)
        {
            return result;
        }
    }
}