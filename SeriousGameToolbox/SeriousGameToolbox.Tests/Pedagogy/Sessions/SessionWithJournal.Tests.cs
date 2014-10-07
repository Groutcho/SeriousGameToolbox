using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using SeriousGameToolbox.Pedagogy.Sessions;
using System;
using System.Threading;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class SessionWithJournal_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullJournal_ThrowsArgumentNullException()
        {
            new SessionWithJournal(null, new Trainee());
        }
    }
}
