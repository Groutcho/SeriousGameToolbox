using NUnit.Framework;
using SeriousGameToolbox.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Commands
{
    [TestFixture]
    public class CommandContainer_Tests
    {
        [Test]
        [Category("Commands")]
        public void ReturnsFalseOnRegisteringAlreadyRegisteredCommand()
        {
            CommandContainer container = new CommandContainer();

            Assert.IsTrue(container.Register(Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "B")));
            Assert.IsFalse(container.Register(Command.CreateCommand(CommandEffects.NoEffect, "CTRL", "B")));
        }
    }
}
