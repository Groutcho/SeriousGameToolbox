using NUnit.Framework;
using SeriousGameToolbox.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Logging
{
    [TestFixture]
    public class FileLogger_Tests
    {
        string appendedLoggerFilename;
        string standardLoggerFilename;

        [SetUp]
        public void SetUp()
        {
            appendedLoggerFilename = Path.Combine(TestContext.CurrentContext.TestDirectory, "appended_logger.csv");
            standardLoggerFilename = Path.Combine(TestContext.CurrentContext.TestDirectory, "standard_logger.csv");
        }

        [Test]
        [Category("Logs")]
        public void LogFileIsCorrectlyWritten()
        {
            string textTolog = "This is line #1";
            FileLoggerChannel logger = new FileLoggerChannel(standardLoggerFilename, append: false);
            logger.Log(textTolog, EntryGravity.Info);
            logger.Dispose();

            StreamReader file = File.OpenText(standardLoggerFilename);
            string line1 = file.ReadLine();
            string[] line1_split = line1.Split(';');
            Assert.AreEqual("DEBUG SESSION", line1_split[0]);
            file.ReadLine();
            string line3 = file.ReadLine();
            string[] line3_split = line3.Split(';');

            Assert.AreEqual("Info", line3_split[0]);
            Assert.AreEqual(textTolog, line3_split[1]);
        }
    }
}
