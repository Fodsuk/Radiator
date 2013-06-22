using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Radiator.Tests.ValidationContextTests
{
    [TestClass]
    public class ValidationContextHasErrorsTests : ValidationContextBaseTests
    {
        [TestMethod]
        public void HasErrors_NoErrors_False()
        {
            var context = GetExampleValidationContext();

            Assert.IsFalse(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_OneGenericError_True()
        {
            var context = GetExampleValidationContext();
            context.AddError(new Error1());

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_MultipleGenericErrors_True()
        {
            var context = GetExampleValidationContext();
            context.AddError(new Error2());
            context.AddError(new Error1());

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_OneSpecificError_True()
        {
            var context = GetExampleValidationContext();
            context.AddErrorFor(new Error1(), c => c.Age);

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_MultipleSpecificError_True()
        {
            var context = GetExampleValidationContext();
            context.AddErrorFor(new Error1(), c => c.Age);
            context.AddErrorFor(new Error1(), c => c.FirstName);

            Assert.IsTrue(context.HasErrors);
        }
    }
}
