using System.Security.Cryptography.X509Certificates;
using Radiator.Core;

namespace Radiator.Tests
{
    public class ValidatorWithPropertyError : CommandValidator<SampleCommand>
    {
        public override void ValidateCommand(SampleCommand command)
        {
            AddErrorFor(new Error1(), cmd => cmd.Age);
        }
    }
}