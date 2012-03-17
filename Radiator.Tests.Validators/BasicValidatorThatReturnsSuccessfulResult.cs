using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Commands;

namespace Radiator.Tests.Validators
{
    public class BasicValidatorThatReturnsSuccessfulResult : ICommandValidator<CommandWithSuccessfulValidation>
    {
        public ProcessResult ValidateCommand(CommandWithSuccessfulValidation commandWithSuccessfulValidationWithFailedValidation)
        {
            return new ProcessResult()
                       {
                           Successful = true,
                           Message = "Validation successful"
                       };
        }
    }
}
