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
            string timeStamp = PreciseTimestamp ? (string.Format(":{0}ms", DateTime.Now.Millisecond.ToString())) : string.Empty;

            writer.WriteLine(string.Format("{0};{1};{2}{3}", gravity, message, DateTime.Now.ToString(), timeStamp));
        }

        public void Dispose()
        {
            writer.Flush();
            writer.Dispose();
        }

        /// <summary>
        /// Will add a millisecond counter to the entry's time stamp.
        /// </summary>
        public bool PreciseTimestamp { get; set; }
    }
}
