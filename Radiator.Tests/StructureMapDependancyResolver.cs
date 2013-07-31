using System.Collections.Generic;
using NUnit.Framework;
using Radiator.Core;
using StructureMap;

namespace Radiator.Tests
{
    public class StructureMapDependancyResolver : ICommandDependencyResolver
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