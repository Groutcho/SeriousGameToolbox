using NUnit.Framework;
using SeriousGameToolbox.Data.Logins;
using SeriousGameToolbox.Pedagogy.Sessions;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Logins
{
    [TestFixture]
    [Category("Logins")]
    public class Login_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new Login(Deliberate.Null as string, "password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyId_ThrowsArgumentException()
        {
            new Login(string.Empty, "password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhitespaceId_ThrowsArgumentException()
        {
            new Login("         ", "password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullPassword_ThrowsArgumentNullException()
        {
            new Login("John Doe", Deliberate.Null as string);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyPassword_ThrowsArgumentException()
        {
            new Login("John Doe", string.Empty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhitespacePassword_ThrowsArgumentException()
        {
            new Login("John Doe", "    ");
        }

        [Test]
        public void Constructor_TrimsId()
        {
            var login = new Login("  John Doe   ", "password");

            Assert.AreEqual("John Doe", login.Id);
        }

        [Test]
        public void Constructor_TrimsPassword()
        {
            var login = new Login("John Doe", "   password   ");

            Assert.AreEqual("password", login.Password);
        }

        [Test]
        public void Equals_ReturnsCorrectEquality()
        {
            var login0 = new Login("John Doe", "password");
            var login1 = new Login("John Doe", "password");
            var login2 = new Login("Jane Doe", "1234");

            Assert.IsTrue(login0.Equals(login1));
            Assert.IsFalse(login1.Equals(login2));
        }

        [Test]
        public void GetHashCode_ReturnsConcatenationOfIdAndPassword()
        {
            string id = "John Doe";
            string password = "My password";
            int expectedHash = id.GetHashCode() + password.GetHashCode();

            var login = new Login(id, password);

            Assert.AreEqual(expectedHash, login.GetHashCode());
        }
    }
}
