using SeriousGameToolbox.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers.Phases
{
    public delegate void PhaseCompletedEvent(Phase sender, PhaseOutput args);

    public class Phase : IUpdatable, IDisposable
    {
        public string Name { get; set; }

        protected double timeSinceStartInSeconds;
        protected bool enabled;

        public event PhaseCompletedEvent Completed;
        public event EventHandler RequestExitApplication;

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

        public virtual void Input(PhaseInput input)
        {

        }

        protected virtual void RaiseRequestExitApplication()
        {
            if (RequestExitApplication != null)
            {
                RequestExitApplication(this, new EventArgs());
            }
        }

        protected virtual void RaisePhaseCompletedEvent(Phase sender, PhaseOutput args)
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
