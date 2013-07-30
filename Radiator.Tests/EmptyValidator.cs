using System;
using Radiator.Core;

namespace Radiator.Tests
{
    public class EmptyValidator : CommandValidator<SampleCommand> 
    {
        public override void ValidateCommand(SampleCommand command)
        {
            
        }
    }
}