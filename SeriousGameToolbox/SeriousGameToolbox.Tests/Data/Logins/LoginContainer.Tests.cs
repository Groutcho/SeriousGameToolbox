using NUnit.Framework;
using SeriousGameToolbox.Data.Logins;
using SeriousGameToolbox.Pedagogy.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Logins
{
    [TestFixture]
    [Category("Logins")]
    public class LoginContainer_Tests
    {
        [Test]
        public void DefaultConstructor_InitializeListOfLogins()
        {
            var container = new LoginContainer();

            Assert.IsNotNull(container.Logins);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnumerableConstructor_NullArgument_ThrowsArgumentNullException()
        {
            new LoginContainer(null);
        }

        [Test]
        public void EnumerableConstructor_AssignsArgumentToListOfLogins()
        {
            var list = new List<Login>(4);

            list.Add(new Login("id1", "pwd1"));
            list.Add(new Login("id2", "pwd2"));
            list.Add(new Login("id3", "pwd3"));
            list.Add(new Login("id4", "pwd4"));

            var container = new LoginContainer(list);

            Assert.AreSame(list, container.Logins);
        }
    }
}
