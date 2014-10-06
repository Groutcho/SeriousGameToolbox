using NUnit.Framework;
using SeriousGameToolbox.Data.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data.Parameters
{
    [TestFixture]
    public class ParameterLoader_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullUri_ThrowsArgumentNullException()
        {
            ParameterLoader loader = new ParameterLoader(null);
        }

        // TODO : add Save() and Load() tests
    }
}
