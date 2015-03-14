using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    [Category("Parameters")]
    public class IntRangeParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new IntRangeParameter(Deliberate.Null as string, "caption", 1, 200, 22);
        }

        [Test]
        public void Clones_Have_Same_Value()
        {
            IntRangeParameter p0 = new IntRangeParameter("id", null, 68, 78, 72);
            IntRangeParameter p1 = p0.Clone() as IntRangeParameter;

            Assert.AreEqual((int)p0.GetValue(), (int)p1.GetValue());
            Assert.AreEqual(p0.Maximum, p1.Maximum);
            Assert.AreEqual(p0.Minimum, p1.Minimum);
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            IntRangeParameter p = new IntRangeParameter("id", null, 68, 78, 72);

            if (p > 5)
            {
                Assert.Pass();
            }


            Assert.Fail();
        }
    }
}
