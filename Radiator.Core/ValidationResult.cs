using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Radiator.Core
{
    public class ValidationResult<TCommand> where TCommand : Command
    {
        private ValidationContext<TCommand> _context;
        
        public ValidationResult(ValidationContext<TCommand> context) {
            _context = context;
        }

        public bool HasErrors { get { return _context.HasErrors; } }

        public bool HasError<TError>() where TError : class
        {
            return _context.HasError<TError>();
        }

        public bool HasError<TError>(Expression<Func<TCommand, object>> expression) where TError : class
        {
            return _context.HasError<TError>(expression);
        }

        public TError GetError<TError>() where TError : class
        {
            return _context.GetError<TError>();
        }

        public TError GetErrorFor<TError>(Expression<Func<TCommand, object>> expression) where TError : class
        {
            return _context.GetErrorFor<TError>(expression);
        }

   }
}
