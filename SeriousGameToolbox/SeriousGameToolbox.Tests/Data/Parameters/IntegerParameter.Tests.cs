using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    public class IntegerParameter_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new IntegerParameter(null, "caption", 1);
        }

        [TestCase]
        public void Clones_Have_Same_Value()
        {
            IntegerParameter p0 = new IntegerParameter("id", null, 68);
            IntegerParameter p1 = p0.Clone() as IntegerParameter;

            Assert.AreEqual(p0.Value, p1.Value);
        }
    }
}
