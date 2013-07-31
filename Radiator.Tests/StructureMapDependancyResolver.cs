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

    public class MockDependencyResolver : ICommandDependencyResolver
    {
        Dictionary<Command, dynamic> validators = new Dictionary<Command, dynamic>(); 

        public void SetValidator<TCommand>(CommandValidator<TCommand> validator) where TCommand : Command
        {
        }

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