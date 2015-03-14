using NUnit.Framework;
using SeriousGameToolbox.Data.Texts;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Texts
{
    [TestFixture]
    [Category("Texts")]
    public class TextUnit_Tests
    {
        IDictionary<CultureInfo, string> invariantCultureTexts;
        IDictionary<CultureInfo, string> twoCultureTexts;
        IDictionary<CultureInfo, string> emptyTexts;
        const string HelloWorld = "Hello, world!";
        const string HelloWorldFr = "Bonjour, monde!";
        readonly CultureInfo frFR = CultureInfo.GetCultureInfo("fr-FR");

        [SetUp]
        public void SetUp()
        {
            invariantCultureTexts = new Dictionary<CultureInfo, string>(1);
            invariantCultureTexts[CultureInfo.InvariantCulture] = HelloWorld;

            twoCultureTexts = new  Dictionary<CultureInfo, string>(2);
            twoCultureTexts[CultureInfo.InvariantCulture] = HelloWorld;
            twoCultureTexts[frFR] = HelloWorldFr;

            emptyTexts = new Dictionary<CultureInfo, string>(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_NullKey_ThrowsArgumentException()
        {
            new TextUnit(Deliberate.Null as string, invariantCultureTexts);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullTexts_ThrowsArgumentNullException()
        {
            new TextUnit("key", Deliberate.Null as IDictionary<CultureInfo, string>);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyTexts_ThrowsArgumentException()
        {
            new TextUnit("key", emptyTexts);
        }

        [Test]
        public void Key_ReturnsKeyDefinedInConstructor()
        {
            TextUnit unit = new TextUnit("the Key", invariantCultureTexts);

            Assert.AreEqual("the Key", unit.Key);
        }

        [Test]
        public void ImplicitStringOperator_ReturnsDefaultValue()
        {
            TextUnit unit = new TextUnit("key", invariantCultureTexts);

            Assert.IsTrue(unit == HelloWorld);
        }

        [Test]
        public void ToString_ReturnsDefaultValue()
        {
            TextUnit unit = new TextUnit("key", invariantCultureTexts);

            Assert.IsTrue(unit.ToString() == HelloWorld);
        }

        [Test]
        public void IsCultureSupported_ReturnsCorrectValue()
        {
            TextUnit unit = new TextUnit("key", invariantCultureTexts);

            Assert.IsFalse(unit.IsCultureSupported(frFR));
            Assert.IsTrue(unit.IsCultureSupported(CultureInfo.InvariantCulture));
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void OverloadedToString_NotSupportedCulture_ThrowsKeyNotFoundException()
        {
            TextUnit unit = new TextUnit("key", invariantCultureTexts);

            CultureInfo impossibleCultureInfo = CultureInfo.GetCultureInfo("sq"); // Albanian !

            unit.ToString(impossibleCultureInfo);
        }

        [Test]
        public void OverloadedToString_ReturnsCorrectValue()
        {
            TextUnit unit = new TextUnit("key", twoCultureTexts);

            Assert.IsTrue(unit.ToString(CultureInfo.InvariantCulture) == HelloWorld);
            Assert.IsTrue(unit.ToString(frFR) == HelloWorldFr);
        }
    }
}
