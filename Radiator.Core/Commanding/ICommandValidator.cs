namespace Radiator.Core.Commanding
{
    public interface ICommandValidator<T> where T : ICommand
    {
        ProcessResult ValidateCommand(T command);
    }
}