using SeriousGameToolbox.Guards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    /// <summary>
    /// Responsible for the binding between a key sequence captured by a listener and the stored commands.
    /// </summary>
    public class CommandContainer
    {
        private List<Command> commands;

        public CommandContainer()
        {
            commands = new List<Command>(16);
        }

        public bool Register(Command command)
        {
            Guard.AgainstNullArgument("command", command);

            if (commands.Contains(command))
            {
                return false;
            }

            commands.Add(command);
            return true;
        }

        internal Command GetCommand(string[] sequence)
        {
            Guard.AgainstNullArgument("sequence", sequence);

            string concat = Command.Concatenate(sequence);

            Command result = commands.FirstOrDefault<Command>(c => c.ConcatenatedForm == concat);

            return result;
        }
    }
}
