using System;
using Radiator.Core;

namespace Radiator.Tests
{
    public class SampleCommand2 : Command
    {
        public decimal Amount { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}