using NUnit.Framework;
using SeriousGameToolbox.Data.Texts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Texts
{
    [TestFixture]
    [Category("Texts")]
    public class TextContainer_Tests
    {
        IDictionary<string, TextUnit> invariantCultureTexts;
        const string HelloWorld = "Hello, world!";
        const string HelloWorldFr = "Bonjour, monde!";
        TextUnit helloWorldText;
        readonly CultureInfo frFR = CultureInfo.GetCultureInfo("fr-FR");
        IEnumerable<CultureInfo> supportedCulturesInvariant;

        [SetUp]
        public void SetUp()
        {
            invariantCultureTexts = new Dictionary<string, TextUnit>(1);

            var dic = new Dictionary<CultureInfo, string>(1);
            dic[CultureInfo.CurrentCulture] = HelloWorld;

            helloWorldText = new TextUnit("helloWorld", dic);

            invariantCultureTexts["helloWorld"] = helloWorldText;

            supportedCulturesInvariant = new List<CultureInfo>(1)
            {
                CultureInfo.InvariantCulture
            };
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverloadedConstructor_NullSupportedCultures_ThrowsArgumentNullException()
        {
            new TextContainer(null, invariantCultureTexts);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverloadedConstructor_NullTexts_ThrowsArgumentNullException()
        {
            new TextContainer(supportedCulturesInvariant, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetCulture_NullArgument_ThrowsArgumentNullException()
        {
            TextContainer container = new TextContainer();
            container.SetCulture(null);
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void SetCulture_UnSupportedCulture_ThrowsKeyNotFoundException()
        {
            TextContainer container = new TextContainer(supportedCulturesInvariant, invariantCultureTexts);
            container.SetCulture(CultureInfo.GetCultureInfo("fr"));
        }

        [Test]
        public void SetCulture_ChangesCulture()
        {
            TextContainer container = new TextContainer(supportedCulturesInvariant, invariantCultureTexts);
            container.SetCulture(CultureInfo.InvariantCulture);

            Assert.AreEqual(CultureInfo.InvariantCulture, container.CurrentCulture);
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetKey_NotFoundKey_ThrowsKeyNotFoundException()
        {
            var result = TextContainer.LoadFromContent(Properties.Resources.text_container_1);

            result.SetCulture(CultureInfo.InvariantCulture);

            result.GetText("invalidKey");
        }

        [Test]
        public void Name_SetNull_ReturnsEmpty()
        {
            var result = TextContainer.LoadFromContent(Properties.Resources.text_container_1);

            result.Name = null;

            Assert.AreEqual(string.Empty, result.Name);
        }
    }
}
