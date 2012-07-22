using Radiator.Core;
using Radiator.Core.Commanding;
using StructureMap;

namespace Radiator.Tests.Bits
{
    public class StructureMapDependancyResolver : IDependencyResolver
    {
        public CommandValidator<TCommand> GetValidator<TCommand>(TCommand command) where TCommand : Command
        {
            return ObjectFactory.TryGetInstance<CommandValidator<TCommand>>();
        }

        public CommandExecutor<TCommand> GetExecutor<TCommand>(TCommand command) where TCommand : Command
        {
            return ObjectFactory.TryGetInstance<CommandExecutor<TCommand>>();
        }
    }
}