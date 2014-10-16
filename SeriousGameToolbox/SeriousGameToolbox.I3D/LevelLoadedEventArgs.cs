using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I3D
{
    public class LevelLoadedEventArgs : EventArgs
    {
        public string Level { get; protected set; }

        public LevelLoadedEventArgs(string level)
        {
            if (string.IsNullOrEmpty(level))
            {
                throw new ArgumentException("the level name cannnot be null nor empty.");
            }

            this.Level = level;
        }
    }
}
