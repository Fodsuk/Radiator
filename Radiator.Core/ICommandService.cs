using System.Threading.Tasks;
using Radiator.Core.Commanding;

namespace Radiator.Core
{
    public interface ICommandService
    {
        ProcessResult Execute<TCommand>(TCommand command) where TCommand : Command;
        Task<ProcessResult> ExecuteAsync<TCommand>(TCommand command) where TCommand : Command;
    }
}