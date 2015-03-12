using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers.Phases
{
    public class PhaseOutput : EventArgs
    {
        private Phase phase;

        public Phase Phase { get { return phase; } }

        public PhaseOutput(Phase phase)
        {
            if (phase == null)
            {
                throw new ArgumentNullException("phase");
            }

            this.phase = phase;
        }
    }
}
