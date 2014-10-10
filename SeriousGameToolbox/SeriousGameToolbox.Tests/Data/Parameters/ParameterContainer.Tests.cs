using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
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
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Get_NotFoundParameter_ThrowsArgumentException()
        {
            BooleanParameter b = new BooleanParameter("id", "caption", true);

            ParameterContainer collection = new ParameterContainer(new[] { b });

            collection.Get<bool>("none");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnumerableConstructor_NullArgument_ThrowsArgumentException()
        {
            ParameterContainer c = null;
            ParameterContainer collection = new ParameterContainer(c);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void EnumerableConstructor_DuplicatedId_ThrowsArgumentException()
        {
            var list = new List<Parameter> (2);

            list.Add(new IntegerParameter("DUPLICATE", "caption 1", 2));
            list.Add(new IntegerParameter("DUPLICATE", "caption 2", 3));

            ParameterContainer c = new ParameterContainer(list);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionConstructor_NullArgument_ThrowsArgumentException()
        {
            IEnumerable<Parameter> c = null;
            ParameterContainer collection = new ParameterContainer(c);
        }
    }
}
