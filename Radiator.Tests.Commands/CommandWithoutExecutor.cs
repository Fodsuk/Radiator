using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Commands
{
    public class CommandWithoutExecutor : ICommand 
    {
        public string AString { get; set; }
    }
}
