using NUnit.Framework;
using SeriousGameToolbox.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Data
{
    [TestFixture]
    [Category("Data")]
    public class FileObject_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullUri_ThrowsArgumentNullException()
        {
            FileObject fo = new FileObject(null);
        }

        [Test]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void Constructor_InvalidUri_ThrowsFileNotFoundException()
        {
            FileObject fo = new FileObject("oyieotkete");
        }

        [Test]
        public void StringOperator_Returns_CorrectValue()
        {
            string filename = "../../TestData/test_file_1.txt";
            FileObject fo = new FileObject(filename);

            string expected = "Hello world !";
            string actual = fo;

            Assert.AreEqual(expected, actual);
        }
    }
}
