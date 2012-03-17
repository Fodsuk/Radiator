using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Commands;

namespace Radiator.Executors
{
    public class BasicExecutorThatReturnsFailedResult : ICommandExecutor<CommandWithFailedExecutor> 
    {
        public ProcessResult ExecuteCommand(CommandWithFailedExecutor command)
        {
            return new ProcessResult()
                       {
                           Successful = false,
                           Message =  "Execution failed"
                       };
        }
    }
}
