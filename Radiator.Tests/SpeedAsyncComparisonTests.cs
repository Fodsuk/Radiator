using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Core.Commanding;
using Radiator.Tests.Bits;
using StructureMap;

namespace Radiator.Tests
{
    [TestClass]
    public class SpeedAsyncComparisonTests
    {
        [TestMethod]
        public void async_execution_start_is_faster_than_sync()
        {
            var slowCommand1 = new SlowCommand();
            var slowCommand2 = new SlowCommand();
            var slowCommand3 = new SlowCommand();

            ObjectFactory.Configure(x =>
                                        {
                                            x.For<ICommandValidator<SlowCommand>>().Use<SlowValidator>();
                                            x.For<ICommandExecutor<SlowCommand>>().Use<SlowExecutor>();
                                        });

            var resolver = new StructureMapDependancyResolver();
            var commandService = new CommandService(new Configuration(resolver));

            var syncWatch = new Stopwatch();
            syncWatch.Start();

            var syncResult1 = commandService.Execute(slowCommand1);
            var syncResult2 = commandService.Execute(slowCommand2);
            var syncResult3 = commandService.Execute(slowCommand3);

            syncWatch.Stop();

            
            var asyncWatch = new Stopwatch();
            asyncWatch.Start();

            var asyncResult1 = commandService.ExecuteAsync(slowCommand1);
            var asyncResult2 = commandService.ExecuteAsync(slowCommand2);
            var asyncResult3 = commandService.ExecuteAsync(slowCommand3);

            Task.WaitAll(asyncResult1, asyncResult2, asyncResult3);

            asyncWatch.Stop();
            
            Assert.IsTrue(syncWatch.Elapsed > asyncWatch.Elapsed);
        }
    }
}
