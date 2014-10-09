using NUnit.Framework;
using SeriousGameToolbox.Controllers;
using SeriousGameToolbox.Tests.Controllers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers
{
    [TestFixture]
    [Category("Controllers")]
    public class Game_Tests
    {
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void Start_NoPhase_ThrowsApplicationException()
        {
            Game game = new Game();
        }

        [Test]
        public void FakeGame_ChainsThreePhasesSuccessfully()
        {
            FakeGame game = new FakeGame();

            game.PhaseDuration = 2d;

            game.Update(0.1d);
            
            Assert.AreEqual("phase 1", game.CurrentPhase);

            game.Update(2.2d);

            Assert.AreEqual("phase 2", game.CurrentPhase);

            game.Update(2.2d);

            Assert.AreEqual("phase 3", game.CurrentPhase);
        }
    }
}
