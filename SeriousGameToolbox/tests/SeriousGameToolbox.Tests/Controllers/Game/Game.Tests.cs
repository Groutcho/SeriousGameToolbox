using NUnit.Framework;
using SeriousGameToolbox.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Game_Test
{
    [TestFixture]
    public class Game_Tests
    {
        public class GameMock : Game
        {
            public double ElapsedTime
            {
                get { return timeSinceStartInSeconds; }
            }

            public void TriggerStart()
            {
                Start();
            }
        }

        [Test]
        [Category("Game")]
        public void ElapsedTimeIsCorrect()
        {
            GameMock mock = new GameMock();
            mock.Update(122d);

            Assert.AreEqual(122d, mock.ElapsedTime, 0.01d);
        }

        [Test]
        [Category("Game")]
        [ExpectedException(typeof(ApplicationException))]
        public void StartThrowsApplicationExceptionWhenNoPhases()
        {
            GameMock mock = new GameMock();
            mock.TriggerStart();
        }
    }
}
