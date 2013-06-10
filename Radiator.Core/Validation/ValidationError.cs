using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Core.Validation
{
	public abstract class ValidationError
	{
		public bool Is<T>() where T : ValidationError
		{
			return this.GetType() == typeof(T);
		}
	}
}
