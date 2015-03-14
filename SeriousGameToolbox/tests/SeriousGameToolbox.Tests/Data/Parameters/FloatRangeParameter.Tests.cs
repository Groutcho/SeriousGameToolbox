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
    public class FloatRangeParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new FloatRangeParameter(Deliberate.Null as string, "caption", 1, 200, 22);
        }

        [Test]
        public void Clones_Have_Same_Value()
        {
            FloatRangeParameter p0 = new FloatRangeParameter("id", null, 68, 78, 72);
            FloatRangeParameter p1 = p0.Clone() as FloatRangeParameter;

            Assert.AreEqual((float)p0.GetValue(), (float)p1.GetValue());
            Assert.AreEqual(p0.Maximum, p1.Maximum);
            Assert.AreEqual(p0.Minimum, p1.Minimum);
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            FloatRangeParameter p = new FloatRangeParameter("id", null, 68, 78, 72);

            if (p > 5)
            {
                Assert.Pass();
            }


            Assert.Fail();
        }
    }
}
