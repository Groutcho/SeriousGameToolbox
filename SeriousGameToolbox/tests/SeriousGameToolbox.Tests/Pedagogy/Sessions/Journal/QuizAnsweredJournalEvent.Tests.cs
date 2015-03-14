using NUnit.Framework;
using SeriousGameToolbox.Pedagogy.Sessions.Journal;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions.Journal
{
    [TestFixture]
    public class QuizAnsweredJournalEvent_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullQuestion_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent(Deliberate.Null as string, "test", "test");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullAnswer_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent("test", Deliberate.Null as string, "test");
        }
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullExpected_ThrowsArgumentNullException()
        {
            new QuizAnsweredJournalEvent("test", "test", Deliberate.Null as string);
        }

        [Test]
        public void Constructor_Sets_Properties()
        {
            var quizEvent = new QuizAnsweredJournalEvent("question", "answer", "expected");

            Assert.AreEqual("question", quizEvent.Question);
            Assert.AreEqual("answer", quizEvent.Answer);
            Assert.AreEqual("expected", quizEvent.Expected);
        }
    }
}
