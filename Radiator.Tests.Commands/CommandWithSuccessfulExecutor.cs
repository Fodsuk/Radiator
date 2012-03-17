using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Commands
{
    public class CommandWithSuccessfulExecutor : ICommand 
    {
        public int SampleInt { get; set; }
        public string AString { get; set; }
    }
}
