using SeriousGameToolbox.Controllers;
using SeriousGameToolbox.Controllers.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Types
{
    internal class FakeGame : Game
    {
        public double PhaseDuration
        {
            set
            {
                foreach (var item in phases)
                {
                    (item as FakePhase).TimeBeforeCompleted = value;
                }
            }
        }

        protected override void Initialize()
        {
            base.Initialize();

            phases.Add(new FakePhase("phase 1"));
            phases.Add(new FakePhase("phase 2"));
            phases.Add(new FakePhase("phase 3"));
        }
    }
}
