using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Radiator.Core;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Bits
{
    public class SlowCommand : ICommand  
    {
    }

    public class SlowValidator : ICommandValidator<SlowCommand>
    {
        public ProcessResult ValidateCommand(SlowCommand command)
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

    public class SlowExecutor : ICommandExecutor<SlowCommand>
    {
        public ProcessResult ExecuteCommand(ICommandService commandService, SlowCommand command)
        {
            int sleepFor = 1500;

            Thread.Sleep(sleepFor);

            return new ProcessResult()
            {
                Successful = true,
                Message = string.Format("Executor ran for {0} miliseconds", sleepFor)
            };
        }

        public ProcessResult OnException<TException>(TException exception, SlowCommand command) where TException : Exception
        {
            return new ProcessResult()
                       {
                           Successful = false,
                           Message = "The shit hit the van"
                       };
        }
    }
   
}
