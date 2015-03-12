using NUnit.Framework;
using SeriousGameToolbox.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Commands
{
    [TestFixture]
    public class Command_Tests
    {
        [Test]
        [Category("Commands")]
        public void CommandConstructorRejectsInvalidKeySequences()
        {
            try
            {
                Command.CreateCommand(CommandEffects.NoEffect, "CTRL");
                Command.CreateCommand(CommandEffects.NoEffect, "SHIFT");
                Command.CreateCommand(CommandEffects.NoEffect, "ALT");
                Command.CreateCommand(CommandEffects.NoEffect, ";");
                Command.CreateCommand(CommandEffects.NoEffect, "$");
                Command.CreateCommand(CommandEffects.NoEffect, "@");

                Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "CTRL");
                Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "SHIFT");
                Command.CreateCommand(CommandEffects.NoEffect, "SHIFT", "SHIFT");
                Command.CreateCommand(CommandEffects.NoEffect, "SHIFT", "ALT");
                Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H", "B");
                Command.CreateCommand(CommandEffects.NoEffect, "ALT", "ALT");
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        [Category("Commands")]
        public void CommandConstructorAcceptsValidKeySequences()
        {
            Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "SHIFT", "K");
            Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");
        }

        [Test]
        [Category("Commands")]
        public void EqualityComparison()
        {
            Command cmd1 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");
            Command cmd2 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");

            Assert.AreEqual(cmd1, cmd2);
        }

        [Test]
        [Category("Commands")]
        public void InequalityComparison()
        {
            Command cmd1 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "B");
            Command cmd2 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");

            Assert.AreNotEqual(cmd1, cmd2);
        }
    }
}
