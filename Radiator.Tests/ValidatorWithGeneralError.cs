using Radiator.Core;

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