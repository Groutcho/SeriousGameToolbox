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
    public class FloatParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new FloatParameter(Deliberate.Null as string, "caption", 1.1f);
        }

        [Test]
        public void Clones_Have_Same_Value()
        {
            FloatParameter p0 = new FloatParameter("id", null, 784.4243f);
            FloatParameter p1 = p0.Clone() as FloatParameter;

            Assert.AreEqual((float)p0.GetValue(), (float)p1.GetValue(), 0.001f);
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            FloatParameter p = new FloatParameter("id", null, 68);

            if (p > 5)
            {
                Assert.Pass();
            }


            Assert.Fail();
        }
    }
}
