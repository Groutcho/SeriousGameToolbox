using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Pedagogy.Sessions;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Threading;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class Session_Tests
    {
        [Test]
        public void Start_Sets_Date()
        {
            Session session = new Session();
            session.Start();

            Assert.AreEqual(session.Date, DateTime.Today);
        }

        [Test]
        public void DefaultConstructor_AssignsDefaultTrainee()
        {
            Session session = new Session();
            Assert.AreEqual(Trainee.Default.Name, session.Trainee.Name);
        }

        [Test]
        public void DefaultConstructor_AssignsId()
        {
            Session session = new Session();
            Assert.AreNotEqual(Guid.Empty, session.Id);
        }

        [Test]
        public void OverloadedConstructor_AssignsId()
        {
            Session session = new Session(new Trainee());
            Assert.AreNotEqual(Guid.Empty, session.Id);
        }

        [Test]
        public void Default_Success_Is_Unknown()
        {
            Session session = new Session(new Trainee());
            Assert.AreEqual(Success.Unknown, session.Success);
        }

        [Test]
        public void Default_Completion_Is_Unknown()
        {
            Session session = new Session(new Trainee());
            Assert.AreEqual(Completion.Unknown, session.Completion);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TraineeConstructor_NullArgument_ThrowsArgumentNullException()
        {
            new Session(Deliberate.Null as Trainee);
        }

        [Test]
        [Category("Long")]
        public void Duration_Is_Correct()
        {
            Session session = new Session();
            session.Start();

            Thread.Sleep(2000);

            session.End();

            Assert.AreEqual(2d, session.Duration.TotalSeconds, 0.1d);
        }
    }
}
