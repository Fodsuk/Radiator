using System;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class CommandThrowsException : ICommand { }

    public class ExecutorThrowsException : ICommandExecutor<CommandThrowsException>
    {
        public ProcessResult ExecuteCommand(ICommandService commandService, CommandThrowsException command)
        {
            throw new NotImplementedException("NotImplementedException thrown in executor");
        }



        public ProcessResult OnException<T>(T exception, CommandThrowsException command) where T : Exception
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