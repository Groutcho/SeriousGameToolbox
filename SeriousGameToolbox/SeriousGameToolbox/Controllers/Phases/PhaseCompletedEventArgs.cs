using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers.Phases
{
    public class PhaseCompletedEventArgs : EventArgs
    {
        private Phase phase;

        public Phase Phase { get { return phase; } }

        public PhaseCompletedEventArgs(Phase phase)
        {
            if (phase == null)
            {
                throw new ArgumentNullException("phase");
            }

            this.phase = phase;
        }
    }
}
