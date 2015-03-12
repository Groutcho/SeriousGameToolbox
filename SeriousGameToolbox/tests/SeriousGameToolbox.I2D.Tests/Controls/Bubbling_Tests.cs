using NUnit.Framework;
using SeriousGameToolbox.I2D.Controls;
using SeriousGameToolbox.I2D.Events;
using SeriousGameToolbox.I2D.Tests.Controls.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests.Controls
{
    [TestFixture]
    [Category("I2D")]
    [Category("Events")]
    public class Bubbling_Tests
    {
        private FakeBubbleControl controlThatTriggersTheEvent;

        [Test]
        public void Event_Is_Bubbled_All_The_Way_Up()
        {
            ControlContainer outermost = new ControlContainer(Area.None);
            ControlContainer intermediate = new ControlContainer(Area.None);
            ControlContainer innermost = new ControlContainer(Area.None);
            controlThatTriggersTheEvent = new FakeBubbleControl();

            innermost.AddControl(controlThatTriggersTheEvent);
            intermediate.AddControl(innermost);
            outermost.AddControl(intermediate);

            outermost.EventBubbled += outmost_EventBubbled;

            controlThatTriggersTheEvent.TriggerEvent();

            // The test should never reach this line.
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Bubbling_A_Null_Event_ThrowsArgumentNullException()
        {
            ControlContainer outermost = new ControlContainer(Area.None);
            ControlContainer intermediate = new ControlContainer(Area.None);
            ControlContainer innermost = new ControlContainer(Area.None);
            controlThatTriggersTheEvent = new FakeBubbleControl();

            innermost.AddControl(controlThatTriggersTheEvent);
            intermediate.AddControl(innermost);
            outermost.AddControl(intermediate);

            controlThatTriggersTheEvent.TriggerNullEvent();
        }

        void outmost_EventBubbled(ControlEvent e)
        {
            if (e is FakeControlEvent)
            {
                var test = e as FakeControlEvent;

                if (controlThatTriggersTheEvent == test.Sender)
                {
                    // Proves that the event has been bubbled all the way from controlThatTriggersTheEvent to the different levels of hierarchy until outermost.
                    Assert.Pass();
                }
            }
            else
            {
                // The test should never reach this line.
                Assert.Fail();
            }
        }
    }
}
