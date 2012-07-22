namespace Radiator.Core.Commanding
{
    public abstract class CommandValidator<T> where T : Command
    {
         public abstract ProcessResult ValidateCommand(T command);
    }
}