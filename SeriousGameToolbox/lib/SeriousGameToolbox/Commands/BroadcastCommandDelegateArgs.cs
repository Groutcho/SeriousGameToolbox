using SeriousGameToolbox.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    public delegate void BroadcastCommandDelegate(BroadcastCommandDelegateArgs args);

    public class BroadcastCommandDelegateArgs
    {
        public Command Command { get; private set; }

        public BroadcastCommandDelegateArgs(Command command)
        {
            Guard.AgainstNullArgument("command", command);

            this.Command = command;
        }
    }
}
