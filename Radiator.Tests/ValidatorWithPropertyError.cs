using System.Security.Cryptography.X509Certificates;
using Radiator.Core;
using Radiator.Tests.Utils;

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