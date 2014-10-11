using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeriousGameToolbox.Logging;
using NUnit.Framework;

namespace SeriousGameToolbox.Tests.Logging.Data
{
    public class TestChannel : ILoggerChannel
    {
        public void Log(object message, EntryGravity gravity)
        {
            Assert.Pass();
        }

        public event EventHandler Disposed;

        public void Dispose()
        {
            if (Disposed != null)
            {
                Disposed(this, new EventArgs());
            }
        }
    }
}
