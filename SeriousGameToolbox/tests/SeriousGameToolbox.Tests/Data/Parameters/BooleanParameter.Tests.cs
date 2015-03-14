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
    public class BooleanParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new BooleanParameter(Deliberate.Null as string, "caption", false);
        }
        [Test]
        public void Clones_Have_Same_Value()
        {
            BooleanParameter p0 = new BooleanParameter("id", null, true);
            BooleanParameter p1 = p0.Clone() as BooleanParameter;

            Assert.AreEqual((bool)p0.GetValue(), (bool)p1.GetValue());
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            BooleanParameter p = new BooleanParameter("id", null, true);

            if (p)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}
