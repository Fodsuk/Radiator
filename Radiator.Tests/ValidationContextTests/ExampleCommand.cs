using Radiator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Tests.ValidationContextTests
{
    public class ExampleCommand : Command
    {
        public string FirstName { get; set; }
        public int Age { get; set; }
    }
}
