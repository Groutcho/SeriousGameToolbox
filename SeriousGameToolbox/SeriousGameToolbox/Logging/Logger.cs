using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Logging
{
    public class Logger
    {
        List<ILoggerChannel> channels;

        static Logger instance;
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void AddChannel(ILoggerChannel channel)
        {
            if (channel == null)
            {
                throw new ArgumentNullException("channel");
            }

            channels.Add(channel);
        }

        public void Log(object message)
        {
            Log(message, EntryGravity.Info);
        }
        
        public void Log(object message, EntryGravity gravity)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            foreach (var channel in channels)
            {
                channel.Log(message, gravity);
            }
        }
    }
}
