using NUnit.Framework;
using SeriousGameToolbox.Controllers.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Tests.Controllers.Phases
{
    [TestFixture]
    public class Phase_Tests
    {
        public class PhaseMock : Phase
        {
            public void RaiseRequestExit()
            {
                RaiseRequestExitApplication();
            }

            public double TimeSinceLastStart
            {
                get { return timeSinceStartInSeconds; }
            }

            public bool Enabled { get { return enabled; } }

            public void RaiseCompleted()
            {
                base.RaisePhaseCompletedEvent(this, new PhaseOutput(this));
            }
        }

        [Test]
        [Category("Phases")]
        public void RaiseRequestExitApplication_RaisesEvent()
        {
            PhaseMock mock = new PhaseMock();

            mock.RequestExitApplication += (sender, args) => Assert.AreEqual(mock, sender);
            mock.RaiseRequestExit();
        }

        [Test]
        [Category("Phases")]
        public void UpdateCorrectTime()
        {
            PhaseMock mock = new PhaseMock();

            mock.Start();
            Assert.IsTrue(mock.Enabled);

            mock.Update(122d);
            Assert.AreEqual(122d, mock.TimeSinceLastStart, 0.01d);

            mock.Stop();
            Assert.IsFalse(mock.Enabled);
        }

        [Test]
        [Category("Phases")]
        public void RaisesPhaseCompleted_ReturnsCorrectOutput()
        {
            PhaseMock mock = new PhaseMock();

            mock.Start();

            mock.Completed += (sender, args) =>
                {
                    Assert.AreEqual(sender, mock);
                    Assert.AreEqual(args.Phase, mock);
                };
            mock.RaiseCompleted();
        }
    }
}
