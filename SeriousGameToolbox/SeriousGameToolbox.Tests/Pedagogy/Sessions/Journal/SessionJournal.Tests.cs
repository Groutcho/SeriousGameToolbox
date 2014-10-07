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
        [TestCase]
        public void Constructor_Creates_Entries()
        {
            SessionJournal journal = new SessionJournal();

            Assert.IsNotNull(journal.Entries);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddEntries_NullEntry_ThrowsArgumentNullException()
        {
            SessionJournal journal = new SessionJournal();
            journal.AddEntry(null);
        }
    }
}
