using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Radiator.Core
{
    public class ValidationContext<TCommand>
    {
        private readonly Dictionary<string, dynamic> _errors = new Dictionary<string, dynamic>();

        public bool HasErrors { get { return _errors.Any(); } }

        public void AddError<TError>(TError error) where TError : class
        {
            if (error == null)
                throw new ArgumentNullException("error", "An error is required.");

            var identifer = BuildIdentifer<TError>();

            if (_errors.ContainsKey(identifer))
                throw new InvalidOperationException("This error already exists.");

            _errors.Add(identifer, error);
        }

        public void AddErrorFor<TError>(TError error, Expression<Func<TCommand, object>> expression) where TError : class
        {
            if (error == null)
                throw new ArgumentNullException("error", "An error is required.");

            if(expression == null)
                throw new ArgumentNullException("expression", "A command property is required to add an error.");

            CheckExpression(expression);

            var identifer = BuildIdentifer<TError>(expression);

            if (_errors.ContainsKey(identifer))
                throw new InvalidOperationException("This error already exists for this property.");

            _errors.Add(identifer, error);
        }



        public bool HasError<TError>() where TError : class
        {
            var identifer = BuildIdentifer<TError>();
            return _errors.Any(e => e.Key.StartsWith(identifer));
        }

        public bool HasError<TError>(Expression<Func<TCommand, object>> expression) where TError : class
        {
            var identifer = BuildIdentifer<TError>(expression);

            return _errors.Any(e => e.Key.StartsWith(identifer));
        }

        public TError GetError<TError>() where TError : class
        {
            var identifer = BuildIdentifer<TError>();

            dynamic error;

            if (_errors.TryGetValue(identifer, out error))
                return error as TError;
            
            return null;
        }

        public TError GetErrorFor<TError>(Expression<Func<TCommand, object>> expression) where TError : class
        {
            var identifer = BuildIdentifer<TError>(expression);

            dynamic error;

            if (_errors.TryGetValue(identifer, out error))
                return error as TError;
            
            return null;
        }

        private void CheckExpression(Expression<Func<TCommand, object>> expression)
        {
            if (!(expression.Body is MemberExpression) && !(expression.Body is UnaryExpression))
                throw new InvalidOperationException("You can only add errors to properties of the command.");
        }

        private string BuildIdentifer<TError>()
        {
            var identifer = typeof(TError).ToString();

            return identifer;
        }

        private string BuildIdentifer<TError>(Expression<Func<TCommand, object>> expression)
        {
            var errorIdentifer = BuildIdentifer<TError>();
            var bodyIdentifer = expression.Body.ToString();

            string identifer = errorIdentifer + bodyIdentifer;

            return identifer;
        }

    }
}
