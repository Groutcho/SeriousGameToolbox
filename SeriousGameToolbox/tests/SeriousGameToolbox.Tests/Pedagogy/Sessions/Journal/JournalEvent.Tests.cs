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
    public class JournalEvent_Tests
    {
        private class TestEvent : JournalEvent
        {
            public TestEvent() : base() { }
            public TestEvent(DateTime date) : base(date) { }
        }

        [Test]
        public void DefaultConstructor_Sets_Id()
        {
            JournalEvent eve = new TestEvent();
            Assert.AreNotEqual(Guid.Empty, eve.Id);
        }

        [Test]
        public void DefaultConstructor_Sets_Date()
        {
            JournalEvent eve = new TestEvent();
            Assert.AreEqual(DateTime.Today, eve.Date.Date);
        }

        [Test]
        public void DateConstructor_Sets_Id()
        {
            JournalEvent eve = new TestEvent(DateTime.Today);
            Assert.AreNotEqual(Guid.Empty, eve.Id);
        }

        [Test]
        public void DateConstructor_Sets_Date()
        {
            JournalEvent eve = new TestEvent(DateTime.Today);
            Assert.AreEqual(DateTime.Today, eve.Date.Date);
        }
    }
}
