using SeriousGameToolbox.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers.Phases
{
    public delegate void PhaseCompletedEvent(Phase sender, PhaseCompletedEventArgs args);

    public class Phase : IUpdatable, IDisposable
    {
        public string Name { get; set; }

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

        public virtual void Update2d()
        {

        }

        protected virtual void RaisePhaseCompletedEvent(Phase sender, PhaseCompletedEventArgs args)
        {
            if (Completed != null)
            {
                Completed(sender, args);
            }
        }

        public virtual void Start()
        {
            timeSinceStartInSeconds = 0;
            enabled = true;
        }

        public virtual void Stop()
        {
            enabled = false;
            timeSinceStartInSeconds = 0;
        }

        public virtual void Dispose()
        {
            Name = null;
        }
    }
}
