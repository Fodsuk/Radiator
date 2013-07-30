using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Radiator.Core
{
    public abstract class CommandValidator<TCommand> where TCommand : Command
    {
        ValidationContext<TCommand> _context = new ValidationContext<TCommand>();

        public ValidationContext<TCommand> ValidationContext { get{return _context;} }

        public abstract void ValidateCommand(TCommand command);

        public void AddError<TError>(TError error) where TError : class
        {
            _context.AddError(error);
        }

        public void AddErrorFor<TError>(TError error, Expression<Func<TCommand, object>> expression) where TError : class
        {
            _context.AddErrorFor(error, expression);          
        }
    }
}

