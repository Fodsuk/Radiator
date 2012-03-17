using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Commands;

namespace Radiator.Tests.Validators
{
    public class BasicValidatorThatReturnsFailedResult : ICommandValidator<CommandWithFailedValidation>
    {
        public ProcessResult ValidateCommand(CommandWithFailedValidation commandWithSuccessfulValidationWithFailedValidation)
        {
            return new ProcessResult()
                       {
                           Successful = false,
                           Message = "Validation failed"
                       };
        }
    }
}
