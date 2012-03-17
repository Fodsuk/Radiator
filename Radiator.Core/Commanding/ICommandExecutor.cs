using System;
using System.Threading.Tasks;

namespace Radiator.Core.Commanding
{
    public interface ICommandExecutor<T> where T : ICommand
    {
        ProcessResult ExecuteCommand(ICommandService commandService, T command);
        ProcessResult OnException<TException>(TException exception, T command) where TException : Exception;
    }
}
