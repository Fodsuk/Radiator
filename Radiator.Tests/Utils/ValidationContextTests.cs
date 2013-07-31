using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Radiator.Tests.Utils
{
    [TestClass]
    public class ValidationContextTests : BaseTests
    {
        [TestMethod]
        public void HasErrors_NoErrors_False()
        {
            var context = GetExampleValidationContext<SampleCommand>();

            Assert.IsFalse(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_OneGenericError_True()
        {
            var context = GetExampleValidationContext<SampleCommand>();
            context.AddError(new Error1());

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_MultipleGenericErrors_True()
        {
            var context = GetExampleValidationContext<SampleCommand>();
            context.AddError(new Error2());
            context.AddError(new Error1());

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_OneSpecificError_True()
        {
            var context = GetExampleValidationContext<SampleCommand>();
            context.AddErrorFor(new Error1(), c => c.Age);

            Assert.IsTrue(context.HasErrors);
        }

        [TestMethod]
        public void HasErrors_MultipleSpecificError_True()
        {
            var context = GetExampleValidationContext<SampleCommand>();
            context.AddErrorFor(new Error1(), c => c.Age);
            context.AddErrorFor(new Error1(), c => c.FirstName);

            Assert.IsTrue(context.HasErrors);
        }
    }
}
