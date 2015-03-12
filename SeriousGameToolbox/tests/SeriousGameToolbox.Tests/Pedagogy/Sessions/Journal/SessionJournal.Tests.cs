using NUnit.Framework;
using SeriousGameToolbox.Pedagogy.Sessions;
using SeriousGameToolbox.Pedagogy.Sessions.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    public class SessionJournal_Tests
    {
        [Test]
        public void Constructor_Creates_Entries()
        {
            SessionJournal journal = new SessionJournal();

            Assert.IsNotNull(journal.Entries);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddEntries_NullEntry_ThrowsArgumentNullException()
        {
            SessionJournal journal = new SessionJournal();
            journal.AddEntry(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEntries_DuplicateEntry_ThrowsArgumentException()
        {
            SessionJournal journal = new SessionJournal();

            var entry = new QuizAnsweredJournalEvent("q", "a", "e");

            journal.AddEntry(entry);
            journal.AddEntry(entry);
        }

        [Test]
        public void AddEntries_SetsEntriesInListProperly()
        {
            SessionJournal journal = new SessionJournal();

            var expected0 = new QuizAnsweredJournalEvent("q", "a", "e");
            var expected1 = new QuizAnsweredJournalEvent("q", "a", "e");

            journal.AddEntry(expected0);
            journal.AddEntry(expected1);

            Assert.AreEqual(expected0, journal.Entries[0]);
            Assert.AreEqual(expected1, journal.Entries[1]);
        }
    }
}
