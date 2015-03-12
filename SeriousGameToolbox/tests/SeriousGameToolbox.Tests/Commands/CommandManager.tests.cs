using NUnit.Framework;
using SeriousGameToolbox.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Commands
{
    [TestFixture]
    [Category("Commands")]
    public class CommandManager_Tests
    {
        [Test]
        public void RaiseCorrectCommandUponEvaluation()
        {
            Command restartGame = Command.CreateCommand(CommandEffects.RestartGame, "CTRL", "SHIFT", "R");

            CommandManager.CommandBroadcast += (c) => Assert.AreEqual(c.Command, restartGame);

            CommandManager.EvaluateSequence("CTRL", "SHIFT", "R");
        }
    }
}
