namespace Radiator.Core
{
    public abstract class BaseCommandValidator<TCommand> where TCommand : Command
    {
         public abstract void ValidateCommand(TCommand command);
    }
}