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

        [Test]
        public void RegisterCommand()
        {
            Command effect1 = Command.CreateCommand("Effect 1", "CTRL", "U");
            Command effect2 = Command.CreateCommand("Effect 2", "CTRL", "U");

            CommandManager.RegisterCommand(effect1);
            Assert.IsFalse(CommandManager.RegisterCommand(effect2));
        }
    }
}
