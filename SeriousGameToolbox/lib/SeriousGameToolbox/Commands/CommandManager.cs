using SeriousGameToolbox.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    /// <summary>
    /// The Command manager will receive key sequences 
    /// to evaluate from one or more Command listeners, 
    /// and will translate them to actual commands broadcast to all subscribed objects.
    /// </summary>
    public static class CommandManager
    {
        public delegate void BroadcastCommandDelegate(BroadcastCommandDelegateArgs args);

        static CommandContainer db;

        public static event BroadcastCommandDelegate CommandBroadcast;

        static CommandManager()
        {
            db = new CommandContainer();
            db.Register(Command.CreateCommand(CommandEffects.RestartGame, "CTRL", "SHIFT", "R"));
            db.Register(Command.CreateCommand(CommandEffects.RestartCurrentPhase, "CTRL", "R"));
        }

        public static bool RegisterCommand(Command command)
        {
            return db.Register(command);
        }

        public static void EvaluateSequence(params string[] sequence)
        {
            Command result = db.GetCommand(sequence);

            Logger.Instance.Log("Received command : " + Command.Concatenate(sequence), EntryGravity.info);

            if (result != null)
            {
                Logger.Instance.Log("Evaluated command : " + result.ToString(), EntryGravity.info);

                if (CommandBroadcast != null)
                {
                    CommandBroadcast(new BroadcastCommandDelegateArgs(result));
                }
            }
        }
    }
}
