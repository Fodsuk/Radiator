using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Radiator.Core.Validation;

namespace Radiator.Core
{
    public class ProcessResult
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
		public ValidationError ValidationError { get; set; }
    }
}
