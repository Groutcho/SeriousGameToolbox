using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Logging
{    
    public interface ILoggerChannel : IDisposable
    {
        void Log(object message, EntryGravity gravity);
    }
}
