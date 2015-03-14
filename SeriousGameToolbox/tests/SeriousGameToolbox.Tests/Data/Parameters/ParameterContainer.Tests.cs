using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    [Category("Parameters")]
    public class ParameterContainer_Tests
    {
        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void Get_InvalidTypeParameter_ThrowsInvalidCastException()
        {
            BooleanParameter b = new BooleanParameter("id", "caption", true);

            ParameterContainer collection = new ParameterContainer(new[] { b });

            collection.Get<String>("id");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsArgumentNullExceptionOnNullParameterContainer()
        {
            new ParameterContainer(Deliberate.Null as ParameterContainer);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Load_ThrowsArgumentNullExceptionOnNullFilename()
        {
            ParameterContainer.Load(Deliberate.Null as string);
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Load_ThrowsFileNotFoundExceptionOnInvalidFilename()
        {
            ParameterContainer.Load("a:/notfound.xml");
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Load_ReturnsCorrectContainer()
        {
            string defaultSettings = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData\\default_settings.xml");
            ParameterContainer actual = ParameterContainer.Load(defaultSettings);

            List<Parameter> parameters = new List<Parameter>(10);
            parameters.Add(new IntegerParameter("test_int", "text_int", 3));
            parameters.Add(new FloatParameter("test_float", "text_float", 565.584f));
            parameters.Add(new IntRangeParameter("test_range_int", "text_range_int", 10, 40, 40));
            parameters.Add(new FloatRangeParameter("test_range_float", "text_range_float", 2.3f, 4.5f, 3.1f));
            parameters.Add(new BooleanParameter("test_boolean", "text_boolean", true));
            parameters.Add(new StringParameter("test_string", "text_string", "Hello, world!"));

            ParameterContainer expected = new ParameterContainer(parameters);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Get_NotFoundParameter_ThrowsArgumentException()
        {
            BooleanParameter b = new BooleanParameter("id", "caption", true);

            ParameterContainer collection = new ParameterContainer(new[] { b });

            collection.Get<bool>("none");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EnumerableConstructor_DuplicatedId_ThrowsArgumentException()
        {
            var list = new List<Parameter>(2);

            list.Add(new IntegerParameter("DUPLICATE", "caption 1", 2));
            list.Add(new IntegerParameter("DUPLICATE", "caption 2", 3));

            ParameterContainer c = new ParameterContainer(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionConstructor_NullArgument_ThrowsArgumentException()
        {
            ParameterContainer collection = new ParameterContainer(Deliberate.Null as IEnumerable<Parameter>);
        }

        [Test]
        public void EqualityComparison()
        {
            List<Parameter> parameters = new List<Parameter>(10);
            parameters.Add(new IntegerParameter("test_int", "text_int", 3));
            parameters.Add(new FloatParameter("test_float", "text_float", 565.584f));
            parameters.Add(new IntRangeParameter("test_range_int", "text_range_int", 10, 40, 40));
            parameters.Add(new FloatRangeParameter("test_range_float", "text_range_float", 2.3f, 4.5f, 3.1f));
            parameters.Add(new BooleanParameter("test_boolean", "text_boolean", true));
            parameters.Add(new StringParameter("test_string", "text_string", "Hello, world!"));

            List<Parameter> parameters2 = new List<Parameter>(10);
            parameters2.Add(new IntegerParameter("test_int", "text_int", 3));
            parameters2.Add(new FloatParameter("test_float", "text_float", 565.584f));
            parameters2.Add(new IntRangeParameter("test_range_int", "text_range_int", 10, 40, 40));
            parameters2.Add(new FloatRangeParameter("test_range_float", "text_range_float", 2.3f, 4.5f, 3.1f));
            parameters2.Add(new BooleanParameter("test_boolean", "text_boolean", true));

            ParameterContainer test = new ParameterContainer(parameters);
            ParameterContainer identical = new ParameterContainer(parameters);
            ParameterContainer different = new ParameterContainer(parameters2);

            Assert.AreEqual(test, identical);
            Assert.AreNotEqual(test, different);
            Assert.AreEqual(test, test);
        }
    }
}
