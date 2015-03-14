using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.Logging
{
    public class FileLoggerChannel : ILoggerChannel
    {
        StreamWriter writer;

        public FileLoggerChannel(string filename, bool append = true)
        {
            writer = new StreamWriter(filename, append: append);
            writer.WriteLine("DEBUG SESSION;" + DateTime.Now.ToString());
            writer.WriteLine();
            writer.AutoFlush = true;
        }

        public void Log(object message, EntryGravity gravity)
        {
            try
            {
                string timeStamp = PreciseTimestamp ? (string.Format(":{0}ms", DateTime.Now.Millisecond.ToString())) : string.Empty;
                writer.WriteLine(string.Format("{0};{1};{2}{3}", gravity, message, DateTime.Now.ToString(), timeStamp));
            }
            catch
            {
                Dispose();
            }
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

        public bool IncludeStackTrace { get; set; }

        public void Log(Exception e)
        {
            writer.WriteLine(e.Message);
            writer.Write(e.StackTrace);
        }
    }
}
