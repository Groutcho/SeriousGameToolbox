using NUnit.Framework;
using SeriousGameToolbox.Pedagogy.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class SessionEvent_Tests
    {
        private class TestEvent : SessionEvent
        {
            public TestEvent() : base() { }
        }

        [TestCase]
        public void Constructor_Sets_Id()
        {
            SessionEvent eve = new TestEvent();
            Assert.AreNotEqual(Guid.Empty, eve.Id);
        }

        [TestCase]
        public void Constructor_Sets_Date()
        {
            SessionEvent eve = new TestEvent();
            Assert.AreEqual(DateTime.Today, eve.Date.Date);
        }
    }
}
