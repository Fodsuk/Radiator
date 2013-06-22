using System.Threading.Tasks;

namespace Radiator.Core
{
    public interface ICommandService
    {
        ValidationResult<TCommand> Execute<TCommand>(TCommand command) where TCommand : Command;
        Task<ValidationResult<TCommand>> ExecuteAsync<TCommand>(TCommand command) where TCommand : Command;
    }
}