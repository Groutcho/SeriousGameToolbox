using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    public class ParameterCollection_Tests
    {
        [TestCase]
        [ExpectedException(typeof(InvalidCastException))]
        public void Get_InvalidTypeParameter_ThrowsInvalidCastException()
        {
            BooleanParameter b = new BooleanParameter("id", "caption", true);

            ParameterCollection collection = new ParameterCollection(new[] { b });

            collection.Get<String>("id");
        }

        [TestCase]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Get_NotFoundParameter_ThrowsArgumentException()
        {
            BooleanParameter b = new BooleanParameter("id", "caption", true);

            ParameterCollection collection = new ParameterCollection(new[] { b });

            collection.Get<bool>("none");
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnumerableConstructor_NullArgument_ThrowsArgumentException()
        {
            ParameterCollection c = null;
            ParameterCollection collection = new ParameterCollection(c);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CollectionConstructor_NullArgument_ThrowsArgumentException()
        {
            IEnumerable<Parameter> c = null;
            ParameterCollection collection = new ParameterCollection(c);
        }
    }
}
