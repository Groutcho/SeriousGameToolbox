using SeriousGameToolbox.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Commands
{
    public delegate void BroadcastCommandDelegate(BroadcastCommandDelegateArgs args);

    public static class CommandManager
    {
        static CommandContainer db;
        static Logger logger;

        public static event BroadcastCommandDelegate CommandBroadcast;

        static CommandManager()
        {
            db = new CommandContainer();
            db.Register(Command.CreateCommand(CommandEffects.RestartGame, "CTRL", "SHIFT", "R"));
            db.Register(Command.CreateCommand(CommandEffects.RestartCurrentPhase, "CTRL", "R"));
        }

        public static void AttachLogger(Logger log)
        {
            Guards.Guard.AgainstNullArgument("logger", log);

            logger = log;
        }

        public static void EvaluateSequence(params string[] sequence)
        {
            Command result = db.GetCommand(sequence);

            if (result != null)
            {
                if (logger != null)
                {
                    logger.Log("Received command : " + result.ToString(), EntryGravity.Info);
                }

                if (CommandBroadcast != null)
                {
                    CommandBroadcast(new BroadcastCommandDelegateArgs(result));
                }
            }
        }
    }
}
