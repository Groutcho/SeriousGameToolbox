using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    [Category("Parameters")]
    public class BooleanParameter_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new BooleanParameter(null, "caption", false);
        }

        [TestCase]
        public void Clones_Have_Same_Value()
        {
            BooleanParameter p0 = new BooleanParameter("id", null, true);
            BooleanParameter p1 = p0.Clone() as BooleanParameter;

            Assert.AreEqual((bool)p0.GetValue(), (bool)p1.GetValue());
        }
    }
}
