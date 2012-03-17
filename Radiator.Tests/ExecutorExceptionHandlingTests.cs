using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Bits;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class ExecutorExceptionHandlingTests
    {
        [TestMethod]
        public void Exception_Is_Handled()
        {
            string subCommandExecMsg = "Sub Command Executed";

            ObjectFactory.Configure(x =>
            {
                x.For<ICommandExecutor<CommandThrowsException>>().Use<ExecutorThrowsException>();
            });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));

            var result = commandService.Execute(new CommandThrowsException());

            string expectedMsg = "NotImplementedException thrown in executor";

            Assert.AreEqual(result.Message, expectedMsg);
        }
    }

}
