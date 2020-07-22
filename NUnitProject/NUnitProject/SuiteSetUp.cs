using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NUnitProject
{
    [SetUpFixture]
    public class SuiteSetUp
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            Logger.Instance.Info("SuiteSetUp Thread-id: " + Thread.CurrentThread.ManagedThreadId);
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {

        }
    }
}
