using System;
using System.Threading.Tasks;

namespace Radiator.Core.Commanding
{
    public abstract class CommandExecutor<T> where T : Command
    {
        public abstract ProcessResult ExecuteCommand(ICommandService commandService, T command);

        public virtual ProcessResult OnException<TException>(TException exception, T command) where TException : Exception
        {
            return new ProcessResult()
            {
                Successful = false,
                Message = exception.Message
            };
        }
    }
}
