using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Commands;

namespace Radiator.Executors
{
    public class BasicExecutorThatReturnsSuccessfulResult : ICommandExecutor<CommandWithSuccessfulExecutor> 
    {
        public ProcessResult ExecuteCommand(CommandWithSuccessfulExecutor command)
        {
            return new ProcessResult()
                       {
                           Successful = true,
                           Message = "Execution successful"
                       };
        }
    }
}
