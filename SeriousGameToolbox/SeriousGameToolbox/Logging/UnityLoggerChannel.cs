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
            switch (gravity)
            {
                case EntryGravity.Trace:
                case EntryGravity.Info: Debug.Log(message);
                    break;
                 case EntryGravity.Warning: Debug.LogWarning(message);
                    break;
                case EntryGravity.Error:
                case EntryGravity.Critical: Debug.LogError(message);
                    break;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
