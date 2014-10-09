using NUnit.Framework;
using SeriousGameToolbox.Controllers.Phases;
using SeriousGameToolbox.Tests.Controllers.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Phases
{
    [TestFixture]
    [Category("Controllers")]
    [Category("Phases")]
    public class Phase_Tests
    {
        FakePhase fakePhase;

        [SetUp]
        public void SetUp()
        {
            fakePhase = new FakePhase("fake phase");
        }

        [Test]
        public void FakePhase_PhaseCompletedEventFired_AfterDelayReached()
        {
            fakePhase.TimeBeforeCompleted = 2d;

            fakePhase.Start();
            fakePhase.Completed += delayReached;
            fakePhase.Update(2.02d);
            Assert.Fail();
        }

        void delayReached(object sender, SeriousGameToolbox.Controllers.Phases.PhaseCompletedEventArgs args)
        {
            (sender as Phase).Completed -= delayReached;
            Assert.Pass();            
        }
    }
}
