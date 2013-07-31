using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radiator.Core;
using Radiator.Tests.Utils;
using StructureMap;

namespace Radiator.Tests
{

    [TestClass]
    public class SpeedAsyncComparisonTests : BaseTests
    {
        [TestMethod]
        public void Execute_AsyncVsSync_AsyncIsFaster()
        {


            var commandService = BuildCommandService(x => x.For<CommandExecutor<SampleCommand>>().Use<EmptyExecutor>());

            var syncWatch = new Stopwatch();
            syncWatch.Start();

            commandService.Execute(new SampleCommand());
            commandService.Execute(new SampleCommand());
            commandService.Execute(new SampleCommand());

            syncWatch.Stop();


            var asyncWatch = new Stopwatch();
            asyncWatch.Start();

            var asyncResult = commandService.ExecuteAsync(new SampleCommand());
            var asyncResult2 = commandService.ExecuteAsync(new SampleCommand());
            var asyncResult3 = commandService.ExecuteAsync(new SampleCommand());

            Task.WaitAll(asyncResult, asyncResult2, asyncResult3);

            asyncWatch.Stop();

            Assert.IsTrue(syncWatch.Elapsed > asyncWatch.Elapsed);
        }
    }
}


