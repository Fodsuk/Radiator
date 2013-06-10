using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Validation
{
	public class TestValidator : CommandValidator<TestCommand>
	{
		public override Core.ProcessResult ValidateCommand(TestCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
