using Radiator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Tests.ValidationContextTests
{
    public abstract class ValidationContextBaseTests
    {
        public ValidationContext<ExampleCommand> GetExampleValidationContext()
        {
            return new ValidationContext<ExampleCommand>();
        }
    }
}
