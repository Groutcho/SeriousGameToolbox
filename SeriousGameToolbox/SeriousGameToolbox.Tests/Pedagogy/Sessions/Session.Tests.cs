using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Pedagogy.Sessions;
using System;
using System.Threading;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class Session_Tests
    {
        [TestCase]
        public void Start_Sets_Date()
        {
            Session session = new Session();
            session.Start();

            Assert.AreEqual(session.Date, DateTime.Today);
        }

        [TestCase]
        public void DefaultConstructor_AssignsDefaultTrainee()
        {
            Session session = new Session();
            Assert.AreSame(Trainee.Default, session.Trainee);
        }

        [TestCase]
        public void DefaultConstructor_AssignsId()
        {
            Session session = new Session();
            Assert.AreNotEqual(Guid.Empty, session.Id);
        }

        [TestCase]
        public void OverloadedConstructor_AssignsId()
        {
            Session session = new Session(new Trainee());
            Assert.AreNotEqual(Guid.Empty, session.Id);
        }

        [TestCase]
        public void Default_Success_Is_Unknown()
        {
            Session session = new Session(new Trainee());
            Assert.AreEqual(Success.Unknown, session.Success);
        }

        [TestCase]
        public void Default_Completion_Is_Unknown()
        {
            Session session = new Session(new Trainee());
            Assert.AreEqual(Completion.Unknown, session.Completion);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TraineeConstructor_NullArgument_ThrowsArgumentNullException()
        {
            new Session(null);
        }

        [TestCase]
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
