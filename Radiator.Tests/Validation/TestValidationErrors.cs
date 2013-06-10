using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Validation;

namespace Radiator.Tests.Validation
{
	public class EmailAddressInUse : ValidationError { }
	public class PasswordDoesNotMeetComplexityRequirements : ValidationError { }
}
