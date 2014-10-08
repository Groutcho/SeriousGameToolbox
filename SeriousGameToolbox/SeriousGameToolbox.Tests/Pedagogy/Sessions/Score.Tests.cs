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
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_RawCannotBeLessThanMin()
        {
            new Score(0, 1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_RawCannotBeGreaterThanMax()
        {
            new Score(3, 1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_MinCannotBeGreaterThanMax()
        {
            new Score(1, 3, 1);
        }
        [Test]
        public void ToPercent_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 10);
            Assert.AreEqual("10%", score.ToPercent());
        }

        [Test]
        public void ToPercentFloat_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 9);
            Assert.AreEqual("11,11%", score.ToPercent(Score.ScorePercentageFormatting.Float));
        }

        [Test]
        public void ToPercentInteger_ReturnsValidValue()
        {
            Score score = new Score(1, 0, 9);
            Assert.AreEqual("11%", score.ToPercent(Score.ScorePercentageFormatting.Integer));
        }
    }
}
