using Radiator.Core;
using Radiator.Core.Commanding;
using StructureMap;

namespace Radiator.Tests.Bits
{
    public class StructureMapDependancyResolver : IDependencyResolver
    {
        public ICommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : ICommand
        {
            return ObjectFactory.TryGetInstance<ICommandValidator<TCommand>>();
        }

        public ICommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : ICommand
        {
            return ObjectFactory.TryGetInstance<ICommandExecutor<TCommand>>();
        }
    }
}