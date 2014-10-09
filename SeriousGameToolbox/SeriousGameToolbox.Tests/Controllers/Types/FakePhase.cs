using SeriousGameToolbox.Controllers.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Types
{
    internal class FakePhase : Phase
    {
        public double TimeBeforeCompleted { get; set; }

        public FakePhase(string name) : base()
        {
            this.name = name;
        }

        public override void Update(double dt)
        {
            base.Update(dt);

            if (timeSinceStartInSeconds >= TimeBeforeCompleted)
            {
                RaisePhaseCompletedEvent(this, new PhaseCompletedEventArgs(this));
            }
        }
    }
}
