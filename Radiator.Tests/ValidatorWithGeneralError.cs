using Radiator.Core;
using Radiator.Tests.Utils;

namespace Radiator.Tests
{
    public class ValidatorWithGeneralError : CommandValidator<SampleCommand>
    {
        public override void ValidateCommand(SampleCommand command)
        {
            AddError(new Error2());
        }
    }
}