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
        DateTime startTime;

        private string Today
        {
            get
            {
                return string.Format("{0}-{1}-{2}", DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            }
        }

        private string Hour
        {
            get
            {
                return string.Format("{0}:{1}:{2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            }
        }

        private string Elapsed
        {
            get
            {
                TimeSpan ts = DateTime.Now - startTime;
                return string.Format("Since start : {0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds);
            }
        }

        public FileLoggerChannel(string filename, bool append = true)
        {
            startTime = DateTime.Now;
            writer = new StreamWriter(filename, append: append);
            writer.WriteLine(string.Format("LOG SESSION ; [{0} {1}]",  Today, Hour));
            writer.WriteLine();
            writer.AutoFlush = true;
        }

        public void Log(object message, EntryGravity gravity)
        {
            try
            {
                writer.WriteLine(string.Format("[{0} {1}] ; {2} ; {3} ; {4}", Today, Hour, Elapsed, gravity.ToString(), message));
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

        public bool IncludeStackTrace { get; set; }

        public void Log(Exception e)
        {
            writer.WriteLine(e.Message);
            writer.Write(e.StackTrace);
        }
    }
}
