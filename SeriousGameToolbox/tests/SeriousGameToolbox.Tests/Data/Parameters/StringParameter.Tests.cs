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
    public class StringParameter_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullId_ThrowsArgumentNullException()
        {
            new StringParameter(Deliberate.Null as string, "caption", "this is the value.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullValue_ThrowsArgumentNullException()
        {
            new StringParameter("id", "caption", Deliberate.Null as string);
        }

        [Test]
        public void Clones_Have_Same_Value()
        {
            StringParameter p0 = new StringParameter("id", null,  "this is the value.");
            StringParameter p1 = p0.Clone() as StringParameter;

            Assert.AreEqual(p0.GetValue(), p1.GetValue());
        }

        [Test]
        public void ImplicitOperator_ReturnsValue()
        {
            StringParameter p = new StringParameter("id", null, "Hello world!");

            if (p == "Hello world!")
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}
