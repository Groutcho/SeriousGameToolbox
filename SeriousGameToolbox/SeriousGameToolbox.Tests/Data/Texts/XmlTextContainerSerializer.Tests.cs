﻿using NUnit.Framework;
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
    [Category("TextSerializers")]
    public class XmlTextContainerSerializer_Tests
    {
        XmlTextContainerSerializer serializer;

        CultureInfo fr = CultureInfo.GetCultureInfo("fr");
        CultureInfo en = CultureInfo.GetCultureInfo("en");
        CultureInfo inv = CultureInfo.InvariantCulture;

        [SetUp]
        public void SetUp()
        {
            serializer = new XmlTextContainerSerializer();
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Load_NullContent_ThrowsArgumentNullException()
        {
            serializer.Parse(null);
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

            Assert.AreEqual("test", result.Name);

            string keyText = "text 1";

            result.SetCulture(inv);            

            Assert.AreEqual("This is text 1", result.GetText(keyText));

            result.SetCulture(en);

            Assert.AreEqual("This is text 1", result.GetText(keyText));

            result.SetCulture(fr);

            Assert.AreEqual("Ceci est texte 1", result.GetText(keyText));
        }
    }
}