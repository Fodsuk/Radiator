using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandThrowsException : Command { }

    public class ExecutorThrowsException : CommandExecutor<CommandThrowsException>
    {
        public override ProcessResult ExecuteCommand(ICommandService commandService, CommandThrowsException command)
        {
            throw new NotImplementedException("NotImplementedException thrown in executor");
        }
        
        public override ProcessResult OnException<T>(T exception, CommandThrowsException command)
        {
            if (exception is NotImplementedException)
            {
                bool here = true;
            }

            return new ProcessResult()
            {
                Message = exception.Message,
                Successful = false
            };

        }
    }
}