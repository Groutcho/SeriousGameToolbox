using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using System;

namespace SeriousGameToolbox.Tests.Pedagogy
{
    [TestFixture]
    public class Trainee_Tests
    {
        [TestCase]
        public void Constructor_AssignsNonEmptyId()
        {
            Trainee trainee = new Trainee();
            Assert.AreNotEqual(Guid.Empty, trainee.Id);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameSetter_ThrowsArgumentNullException()
        {
            Trainee trainee = new Trainee();
            trainee.Name = null;
        }

        [TestCase]
        public void NameSetter_TrimsInput()
        {
            Trainee trainee = new Trainee();
            trainee.Name = "  Bobby ";

            Assert.AreEqual("Bobby", trainee.Name);
        }
    }
}
