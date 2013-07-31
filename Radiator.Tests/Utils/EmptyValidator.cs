using Radiator.Core;

namespace Radiator.Tests.Utils
{
    public class EmptyValidator : CommandValidator<SampleCommand> 
    {
        public override void ValidateCommand(SampleCommand command)
        {
            
        }
    }
}