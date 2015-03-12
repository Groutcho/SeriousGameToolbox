using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.Logging
{
    public class UnityLoggerChannel : ILoggerChannel
    {
        public void Log(object message, EntryGravity gravity)
        {
            string messageStr = message.ToString() + (PreciseTimestamp ? DateTime.Now.Millisecond.ToString() : string.Empty);

            switch (gravity)
            {
                case EntryGravity.Trace:
                case EntryGravity.Info: Debug.Log(messageStr);
                    break;
                case EntryGravity.Warning: Debug.LogWarning(messageStr);
                    break;
                case EntryGravity.Error:
                case EntryGravity.Critical: Debug.LogError(messageStr);
                    break;
            }
        }

        public void Dispose()
        {
            
        }


        public bool PreciseTimestamp { get; set; }


        public void Log(Exception e)
        {
            Debug.LogError(e.Message);
            Debug.LogError(e.StackTrace);
        }

        public bool IncludeStackTrace { get; set; }
    }
}
