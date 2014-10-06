using NUnit.Framework;
using SeriousGameToolbox.Pedagogy.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Pedagogy.Sessions
{
    [TestFixture]
    [Category("Session")]
    public class Score_Tests
    {
        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_RawCannotBeLessThanMin()
        {
            new Score(0, 1, 2);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_RawCannotBeGreaterThanMax()
        {
            new Score(3, 1, 2);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MinCannotBeGreaterThanMax()
        {
            new Score(1, 3, 1);
        }
        [TestCase]
        public void ToPercent_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 10);
            Assert.AreEqual("10%", score.ToPercent());
        }

        [TestCase]
        public void ToPercentFloat_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 9);
            Assert.AreEqual("11,11%", score.ToPercent(Score.ScorePercentageFormatting.Float));
        }

        [TestCase]
        public void ToPercentInteger_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 9);
            Assert.AreEqual("11%", score.ToPercent(Score.ScorePercentageFormatting.Integer));
        }
    }
}
