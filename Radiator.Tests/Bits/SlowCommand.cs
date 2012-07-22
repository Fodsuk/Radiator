using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class SlowCommand : Command  
    {
    }

    public class SlowValidator : CommandValidator<SlowCommand>
    {
        public override ProcessResult ValidateCommand(SlowCommand command)
        {
            int sleepFor = 1500;

            Thread.Sleep(sleepFor);

            return new ProcessResult()
                       {
                           Successful = true,
                           Message = string.Format("Validator ran for {0} miliseconds", sleepFor)
                       };
        }
    }

    public class SlowExecutor : CommandExecutor<SlowCommand>
    {
        public override ProcessResult ExecuteCommand(ICommandService commandService, SlowCommand command)
        {
            int sleepFor = 1500;

            Thread.Sleep(sleepFor);

            return new ProcessResult()
            {
                Successful = true,
                Message = string.Format("Executor ran for {0} miliseconds", sleepFor)
            };
        }
    }
   
}
