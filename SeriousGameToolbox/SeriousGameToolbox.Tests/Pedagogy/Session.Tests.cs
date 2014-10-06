using NUnit.Framework;
using SeriousGameToolbox.Pedagogy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Pedagogy
{
    [TestFixture]
    public class Session_Tests
    {
        public void Start_Sets_Date()
        {
            Session session = new Session();
            session.Start();

            Assert.AreEqual(session.Date, DateTime.Today);
        }
    }
}
