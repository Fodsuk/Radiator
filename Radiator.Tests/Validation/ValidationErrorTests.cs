using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core;

namespace Radiator.Tests.Validation
{
	public class ValidationErrorTests
	{
		public void Test()
		{
			ICommandService commandService = new CommandService(null);

			var result = commandService.Execute(new TestCommand());

			if (!result.Successful)
			{
				if (result.ValidationError.Is<PasswordDoesNotMeetComplexityRequirements>())
				{
					//Do something
				}

				if (result.ValidationError.Is<EmailAddressInUse>())
				{
					//Do something
				}
			}
		}
	}
}
