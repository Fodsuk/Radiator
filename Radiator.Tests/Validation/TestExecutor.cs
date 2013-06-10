using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Commanding;

namespace Radiator.Tests.Validation
{
	public class TestExecutor : CommandExecutor<TestCommand>
	{
		public override Core.ProcessResult ExecuteCommand(Core.ICommandService commandService, TestCommand command)
		{
			throw new NotImplementedException();
		}
	}
}
