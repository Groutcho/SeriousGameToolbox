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
    public class IntegerParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new IntegerParameter(Deliberate.Null as string, "caption", 1);
        }

        [Test]
        public void Clones_Have_Same_Value()
        {
            IntegerParameter p0 = new IntegerParameter("id", null, 68);
            IntegerParameter p1 = p0.Clone() as IntegerParameter;

            Assert.AreEqual((int)p0.GetValue(), (int)p1.GetValue());
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            IntegerParameter p = new IntegerParameter("test", "test", 455);

            if (p > 400)
            {
                Assert.Pass();
            }


            Assert.Fail();
        }
    }
}
