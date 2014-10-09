using SeriousGameToolbox.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers.Phases
{
    public delegate void PhaseCompletedEvent(Phase sender, PhaseCompletedEventArgs args);

    public class Phase : IUpdatable
    {
        protected string name = string.Empty;
        public string Name { get { return name; } }

        protected double timeSinceStartInSeconds;
        protected bool enabled;

        public event PhaseCompletedEvent Completed;

        public virtual void Update(double dt)
        {
            if (enabled)
            {
                timeSinceStartInSeconds += dt;
            }
        }

        protected virtual void RaisePhaseCompletedEvent(Phase sender, PhaseCompletedEventArgs args)
        {
            if (Completed != null)
            {
                Completed(sender, args);
            }
        }

        public void Start()
        {
            timeSinceStartInSeconds = 0;
            enabled = true;
        }

        public void Stop()
        {
            enabled = false;
            timeSinceStartInSeconds = 0;
        }
    }
}
