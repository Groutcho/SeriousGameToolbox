using SeriousGameToolbox.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
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
