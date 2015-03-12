using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Pedagogy.Sessions;
using SeriousGameToolbox.Pedagogy.Sessions.Journal;
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
            new SessionWithJournal(null, new Trainee());
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
