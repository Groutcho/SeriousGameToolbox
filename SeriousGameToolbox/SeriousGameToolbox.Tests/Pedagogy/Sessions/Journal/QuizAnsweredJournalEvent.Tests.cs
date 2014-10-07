using NUnit.Framework;
using SeriousGameToolbox.Pedagogy.Sessions.Journal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions.Journal
{
    [TestFixture]
    public class QuizAnsweredJournalEvent_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuestion_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent(null, "test", "test");
        }
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullAnswer_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent("test", null, "test");
        }
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullExpected_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent("test", "test", null);
        }

        [TestCase]
        public void Constructor_Sets_Properties()
        {
            var quizEvent = new QuizAnsweredJournalEvent("question", "answer", "expected");

            Assert.AreEqual("question", quizEvent.Question);
            Assert.AreEqual("answer", quizEvent.Answer);
            Assert.AreEqual("expected", quizEvent.Expected);
        }
    }
}
