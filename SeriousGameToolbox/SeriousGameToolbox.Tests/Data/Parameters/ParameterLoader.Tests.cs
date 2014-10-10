using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    [Category("Parameters")]
    public class ParameterLoader_Tests
    {
        private class InvalidParameter : Parameter
        {
            public InvalidParameter()
                : base("invalid", "invalid")
            {

            }

            public override object GetValue()
            {
                return null;
            }

            public override Parameter Clone()
            {
                return null;
            }

            public override bool Equals(Parameter other)
            {
                return false;
            }
        }

        string filename;

        [SetUp]
        public void SetUp()
        {
            filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp_parameters.xml");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullUri_ThrowsArgumentNullException()
        {
            ParameterLoader loader = new ParameterLoader(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_EmptyUri_ThrowsArgumentException()
        {
            ParameterLoader loader = new ParameterLoader(string.Empty);
        }

        [Test]
        public void Load_CreatesValidCollection()
        {
            string content = Properties.Resources.default_settings;

            using (StreamWriter w = new StreamWriter(filename))
            {
                w.Write(content);
            }

            ParameterLoader loader = new ParameterLoader(filename);

            var collection = loader.Load();

            bool b = collection.Get<bool>("TEST_BOOL");
            int i = collection.Get<int>("TEST_INT");

            Assert.IsTrue(b);
            Assert.AreEqual(3, i);
        }

        [Test]
        [ExpectedException(typeof(ParameterLoader.InvalidParameterTypeException))]
        public void Save_UnknownParameterTypeAsked_ThrowsInvalidParameterTypeException()
        {
            ParameterLoader loader = new ParameterLoader(filename);

            var invalidCollection = new ParameterContainer(new List<Parameter> { new InvalidParameter() });

            loader.Save(invalidCollection);
        }

        [Test]
        public void Save_CreatesValidFile()
        {
            string content = Properties.Resources.default_settings;

            using (StreamWriter w = new StreamWriter(filename))
            {
                w.Write(content);
            }

            ParameterLoader loader = new ParameterLoader(filename);

            var collection = loader.Load();
            loader.Save(collection);
            collection = loader.Load();

            bool b = collection.Get<bool>("TEST_BOOL");
            int i = collection.Get<int>("TEST_INT");

            Assert.IsTrue(b);
            Assert.AreEqual(3, i);
        }

        [Test]
        public void Equals_ReturnsCorrectValue()
        {
            int expectedInt = 46546440;
            float expectedFloat = 4487.2f;
            bool expectedBool = true;
            string expectedString = "Hello, world!";
            float expectedFloatRange = 3.1f;
            int expectedIntRange = 35;

            List<Parameter> list = new List<Parameter>(5);
            list.Add(new BooleanParameter("bool", "bool", expectedBool));

            list.Add(new StringParameter("string", "string", expectedString));

            list.Add(new IntegerParameter("integer", "integer", expectedInt));
            list.Add(new IntRangeParameter("intrange", "intrange", -7, 247, expectedIntRange));

            list.Add(new FloatParameter("float", "float", expectedFloat));
            list.Add(new FloatRangeParameter("floatrange", "floatrange", 2.3f, 4.8f, expectedFloatRange));

            List<Parameter> list2 = new List<Parameter>(5);
            list2.Add(new BooleanParameter("bool", "bool", expectedBool));

            list2.Add(new StringParameter("string", "string", expectedString));

            list2.Add(new IntegerParameter("integer", "integer", expectedInt));
            list2.Add(new IntRangeParameter("intrange", "intrange", -7, 247, expectedIntRange));

            list2.Add(new FloatParameter("float", "float", expectedFloat));
            list2.Add(new FloatRangeParameter("floatrange", "floatrange", 2.3f, 4.8f, expectedFloatRange));

            ParameterContainer fullCollection1 = new ParameterContainer(list);

            ParameterContainer fullCollection2 = new ParameterContainer(list2);

            Assert.IsTrue(fullCollection1.Equals(fullCollection2));
        }

        [Test]
        public void Save_EachTypeOfParameter_CreatesValidFile()
        {
            int expectedInt = 46546440;
            float expectedFloat = 4487.2f;
            bool expectedBool = true;
            string expectedString = "Hello, world!";
            float expectedFloatRange = 3.1f;
            int expectedIntRange = 35;

            List<Parameter> list = new List<Parameter>(5);
            list.Add(new BooleanParameter("bool", "bool", expectedBool));

            list.Add(new StringParameter("string", "string", expectedString));

            list.Add(new IntegerParameter("integer", "integer", expectedInt));
            list.Add(new IntRangeParameter("intrange", "intrange", -7, 247, expectedIntRange));

            list.Add(new FloatParameter("float", "float", expectedFloat));
            list.Add(new FloatRangeParameter("floatrange", "floatrange", 2.3f, 4.8f, expectedFloatRange));

            ParameterContainer fullCollection = new ParameterContainer(list);

            ParameterLoader loader = new ParameterLoader(filename);
            loader.Save(fullCollection);
            var loadedCollection = loader.Load();

            bool actualBool = loadedCollection.Get<bool>("bool");
            string actualString = loadedCollection.Get<string>("string");
            int actualInt = loadedCollection.Get<int>("integer");
            float actualFloat = loadedCollection.Get<float>("float");
            float actualFloatRange = loadedCollection.Get<float>("floatrange");
            int actualIntRange = loadedCollection.Get<int>("intrange");

            Assert.AreEqual(expectedBool, actualBool);
            Assert.AreEqual(expectedFloat, actualFloat);
            Assert.AreEqual(expectedFloatRange, actualFloatRange);
            Assert.AreEqual(expectedString, actualString);
            Assert.AreEqual(expectedInt, actualInt);
            Assert.AreEqual(expectedIntRange, actualIntRange);
        }
    }
}
