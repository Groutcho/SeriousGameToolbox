using NUnit.Framework;
using SeriousGameToolbox.Logging;
using SeriousGameToolbox.Tests._utils;
using SeriousGameToolbox.Tests.Logging.Data;
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
        [SetUp]
        public void SetUp()
        {
            Logger.Reset();
        }

        [Test]
        public void Instance_IsNotNull()
        {
            Assert.IsNotNull(Logger.Instance);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddChannel_NullChannel_ThrowsArgumentNullException()
        {
            Logger.Instance.AddChannel(Deliberate.Null as ILoggerChannel);
        }

        [Test]
        public void Log_CallsChannels_Log()
        {
            Logger.Instance.AddChannel(new TestChannel());

            Logger.Instance.Log("this is a log entry.");
            Assert.Fail();
        }

        [Test]
        public void ClearChannels_Clears_Channels()
        {
            var log = Logger.Instance;

            Assert.IsNotNull(log.Channels);

            log.AddChannel(new TestChannel());

            Assert.AreEqual(1, log.Channels.Count);

            log.ClearChannels();

            Assert.IsNotNull(log.Channels);
            Assert.AreEqual(0, log.Channels.Count);
        }

        [Test]
        public void ClearChannels_DisposesChannels()
        {
            var log = Logger.Instance;

            var testChannel = new TestChannel();
            testChannel.Disposed += testChannel_Disposed;
            log.AddChannel(testChannel);

            log.ClearChannels();
            Assert.Fail();
        }

        void testChannel_Disposed(object sender, EventArgs e)
        {
            (sender as TestChannel).Disposed -= testChannel_Disposed;
            Assert.Pass();
        }
    }
}
