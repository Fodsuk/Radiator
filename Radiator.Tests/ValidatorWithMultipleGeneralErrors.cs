using Radiator.Core;
using Radiator.Tests.Utils;

namespace Radiator.Tests
{
    public class ValidatorWithMultipleGeneralErrors : CommandValidator<SampleCommand>
    {
        public override void ValidateCommand(SampleCommand command)
        {
            AddError(new Error1());
            AddError(new Error2());
        }
    }
}