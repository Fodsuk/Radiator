using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Commands;

namespace Radiator.Tests.Validators
{
    public class SubClassedValidator : IBaseValidator<CommandWithSubClassedValidator>
    {
        public ProcessResult ValidateCommand(CommandWithSubClassedValidator command)
        {
            return new ProcessResult()
                       {
                           Successful = true
                       };
        }

        public int FieldOnBaseValidator { get; set; }
    }

    public interface IBaseValidator<T> : ICommandValidator<T> where T : ICommand 
    {
        int FieldOnBaseValidator { get; set; }
    }
}
