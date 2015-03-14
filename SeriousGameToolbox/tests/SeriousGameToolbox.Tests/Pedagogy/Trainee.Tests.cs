using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Tests._utils;
using System;

namespace SeriousGameToolbox.Tests.Pedagogy
{
    [TestFixture]
    public class Trainee_Tests
    {
        [Test]
        public void Constructor_AssignsNonEmptyId()
        {
            Trainee trainee = new Trainee();
            Assert.AreNotEqual(Guid.Empty, trainee.Id);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameSetter_ThrowsArgumentNullException()
        {
            Trainee trainee = new Trainee();
            trainee.Name = Deliberate.Null as string;
        }

        [Test]
        public void NameSetter_TrimsInput()
        {
            Trainee trainee = new Trainee();
            trainee.Name = "  Bobby ";

            Assert.AreEqual("Bobby", trainee.Name);
        }

        [Test]
        public void DefaultTraine_ReturnsCorrectValue()
        {
            Trainee trainee = Trainee.Default;
           
            Assert.AreEqual("Default trainee", trainee.Name);
        }

        [Test]
        public void Equals_ReturnsCorrectValue()
        {
            Trainee trainee = Trainee.Default;
            Trainee trainee2 = Trainee.Default;

            Assert.IsTrue(trainee.Equals(trainee2));
        }
    }
}
