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
        [TestCase]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullUri_ThrowsArgumentNullException()
        {
            ParameterLoader loader = new ParameterLoader(null);
        }

        // TODO : add Save() and Load() tests

        [TestCase]
        public void Load_CreatesValidCollection()
        {
            string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp_parameters.xml");
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
    }
}
