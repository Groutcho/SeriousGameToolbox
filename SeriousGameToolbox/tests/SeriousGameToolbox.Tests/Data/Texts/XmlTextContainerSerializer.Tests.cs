using NUnit.Framework;
using SeriousGameToolbox.Data.Texts;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Texts
{
    [TestFixture]
    [Category("Texts")]
    [Category("TextSerializers")]
    public class XmlTextContainerSerializer_Tests
    {
        XmlTextContainerParser serializer;

        CultureInfo fr = CultureInfo.GetCultureInfo("fr");
        CultureInfo en = CultureInfo.GetCultureInfo("en");
        CultureInfo inv = CultureInfo.InvariantCulture;

        [SetUp]
        public void SetUp()
        {
            serializer = new XmlTextContainerParser();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Load_NullContent_ThrowsArgumentNullException()
        {
            serializer.Parse(Deliberate.Null as string);
        }

        [Test]
        public void Load_SampleContainer_ReturnsCorrectValue()
        {
            //<text_container name="test">
            //    <supported_cultures>
            //        <culture>en</culture>
            //        <culture>fr</culture>
            //        <culture>invariant</culture>
            //    </supported_cultures>
            //    <texts>
            //        <text key="text 1">
            //            <culture name="invariant" uses="en"/>
            //            <culture name="en">This is text 1</culture>
            //            <culture name="fr">Ceci est texte 1</culture>
            //        </text>
            //    </texts>
            //</text_container>

            var result = serializer.Parse(Properties.Resources.text_container_1);

            CheckAgainstSampleFile(result);
        }

        private void CheckAgainstSampleFile(TextContainer result)
        {
            Assert.AreEqual("test", result.Name);

            string keyText = "text 1";

            result.SetCulture(inv);

            Assert.AreEqual("This is text 1", result.GetText(keyText));

            result.SetCulture(en);

            Assert.AreEqual("This is text 1", result.GetText(keyText));

            result.SetCulture(fr);

            Assert.AreEqual("Ceci est texte 1", result.GetText(keyText));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadFromFilename_NullFilename_ThrowsArgumentNullException()
        {
            TextContainer.Load(null);
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void LoadFromFilename_InvalidFilename_ThrowsFileNotFoundException()
        {
            TextContainer.Load("invalid filename");
        }

        [Test]
        public void LoadFromFilename_SampleContainer_ReturnsCorrectValue()
        {
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SeriousGameToolbox");
            string filename = Path.Combine(dir, "sample_text_container.xml");

            Directory.CreateDirectory(dir);

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(Properties.Resources.text_container_1);
            }

            var result = TextContainer.Load(filename);

            CheckAgainstSampleFile(result);
        }
    }
}
