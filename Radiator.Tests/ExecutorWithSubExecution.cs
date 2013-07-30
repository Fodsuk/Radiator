using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;

namespace Radiator.Tests
{
    public class ExecutorWithSubExecution : CommandExecutor<SampleCommand2>
    {
        public override void ExecuteCommand(ICommandService commandService, SampleCommand2 command)
        {
            commandService.Execute(new SampleCommand());
        }
    }
}
