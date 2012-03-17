using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Commands
{
    public class CommandWithFailedValidation : ICommand 
    {
        public double FirstDouble { get; set; }
        public double SecondDouble { get; set; }
        public string FirstString { get; set; }
    }
}
