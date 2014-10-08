using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data
{
    public abstract class Manifest
    {
        public abstract string ApplicationName { get; }
        public abstract Version ApplicationVersion { get; }
        public abstract bool IsRelease { get; }

        public abstract void Load();
    }
}
