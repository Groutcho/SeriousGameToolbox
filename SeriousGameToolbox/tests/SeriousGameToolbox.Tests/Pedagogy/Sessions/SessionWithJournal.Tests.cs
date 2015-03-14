using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Pedagogy.Sessions;
using SeriousGameToolbox.Pedagogy.Sessions.Journal;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Threading;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class SessionWithJournal_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullJournal_ThrowsArgumentNullException()
        {
            new SessionWithJournal(Deliberate.Null as SessionJournal, new Trainee());
        }

        [Test]
        public void Constructor_ValidJournal_AssignJournalToProperty()
        {
            SessionJournal expected = new SessionJournal();
            var session = new SessionWithJournal(expected, new Trainee());

            Assert.AreEqual(expected, session.Journal);
        }
    }
}
