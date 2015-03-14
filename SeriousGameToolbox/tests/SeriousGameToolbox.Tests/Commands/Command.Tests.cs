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
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "SHIFT"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "ALT"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, ";"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "$"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "@"));

            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "CTRL"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "SHIFT"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "SHIFT", "SHIFT"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "SHIFT", "ALT"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H", "B"));
            Assert.Throws<ArgumentException>(() => Command.CreateCommand(CommandEffects.NoEffect, "ALT", "ALT"));
        }

        [Test]
        [Category("Commands")]
        public void CommandConstructorAcceptsValidKeySequences()
        {
            Assert.DoesNotThrow(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "SHIFT", "K"));
            Assert.DoesNotThrow(() => Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H"));
        }

        [Test]
        [Category("Commands")]
        public void ConcatenateReturnsCorrectSequence()
        {
            Assert.AreEqual("CTRL+SHIFT+K", Command.Concatenate("CTRL", "SHIFT", "K"));
            Assert.AreEqual("CTRL+ALT+SHIFT+T", Command.Concatenate("CTRL", "ALT", "SHIFT", "T"));
            Assert.AreEqual("CTRL+U", Command.Concatenate("CTRL", "U"));
            Assert.AreEqual("SHIFT+B", Command.Concatenate("SHIFT", "B"));
        }

        [Test]
        [Category("Commands")]
        public void EqualityComparison()
        {
            Command cmd1 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");
            Command cmd2 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");

            Assert.AreEqual(cmd1, cmd2);
            Assert.AreEqual(cmd1, (object)cmd2);
        }

        [Test]
        [Category("Commands")]
        public void InequalityComparison()
        {
            Command cmd1 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "B");
            Command cmd2 = Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "H");

            Assert.AreNotEqual(cmd1, cmd2);
            Assert.AreNotEqual(cmd1, new object());
        }
    }
}
