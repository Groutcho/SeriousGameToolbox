using NUnit.Framework;
using SeriousGameToolbox.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Logging
{
    [TestFixture]
    [Category("Logs")]
    public class Logger_Tests
    {
        [Test]
        public void Instance_IsNotNull()
        {
            Assert.IsNotNull(Logger.Instance);
        }
    }
}
