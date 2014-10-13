using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.Logging
{
    public class FileLoggerChannel : ILoggerChannel
    {
        StreamWriter writer;

        public FileLoggerChannel(string filename)
        {
            writer = new StreamWriter(filename);
            writer.AutoFlush = true;
        }

        public void Log(object message, EntryGravity gravity)
        {
            writer.WriteLine(string.Format("{0};{1};{2}", gravity, message, DateTime.Now.ToString()));
        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
        }
    }
}
