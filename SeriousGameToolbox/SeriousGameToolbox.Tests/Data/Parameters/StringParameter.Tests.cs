using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    public class StringParameter_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new StringParameter(null, "caption", "this is the value.");
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullValue_ThrowsArgumentNullException()
        {
            new StringParameter("id", "caption", null);
        }

        [TestCase]
        public void Clones_Have_Same_Value()
        {
            StringParameter p0 = new StringParameter("id", null,  "this is the value.");
            StringParameter p1 = p0.Clone() as StringParameter;

            Assert.AreEqual(p0.Value, p1.Value);
        }
    }
}
