using Radiator.Core;
using Radiator.Tests.Utils;

namespace Radiator.Tests
{
    public class ValidatorWithMultiplePropertiesThatHaveAnError : CommandValidator<SampleCommand>
    {
        public override void ValidateCommand(SampleCommand command)
        {
            AddErrorFor(new Error1(), cmd => cmd.Age);
            AddErrorFor(new Error2(), cmd => cmd.FirstName);
        }
    }
}