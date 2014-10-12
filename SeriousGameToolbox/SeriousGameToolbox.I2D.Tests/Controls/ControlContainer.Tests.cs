using NUnit.Framework;
using SeriousGameToolbox.I2D.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests.Controls
{
    [TestFixture]
    [Category("I2D")]
    [Category("ControlContainer")]
    public class ControlContainer_Tests
    {
        private class FakeControl : Control
        {
            public FakeControl(Area area) : base(area)
            {

            }
        }

        [Test]
        public void Find_OneNestedControl_ReturnsCorrectResult()
        {
            var screen = new ScreenControl();
            screen.Name = "screen";

            float buttonWidth = 100;
            float buttonHeight = 40;

            var button1 = new FakeControl(new Area(40, 40, buttonWidth, buttonHeight));
            button1.Name = "button1";

            var button2 = new FakeControl(new Area(5 + 40, 40, buttonWidth, buttonHeight));
            button2.Name = "button2";

            var button3 = new FakeControl(new Area(40, 5 + 40, buttonWidth, buttonHeight));
            button3.Name = "button3";

            var button4 = new FakeControl(new Area(5 + 40, 5, buttonWidth, buttonHeight));
            button4.Name = "button4";

            var container = new BoxControl(new Area(5 + 40, 5, 300, 300));
            container.Name = "container";

            var button5 = new FakeControl(new Area(10, 10, buttonWidth, buttonHeight));
            button5.Name = "button1";

            var container_button2 = new FakeControl(new Area(5 + 10, 10, buttonWidth, buttonHeight));
            container_button2.Name = "button2";

            container.AddControl(button5);
            container.AddControl(container_button2);

            screen.AddControl(button1);
            screen.AddControl(button2);
            screen.AddControl(button3);
            screen.AddControl(button4);

            screen.AddControl(container);

            var actual = screen.Find("container/button2");

            Assert.AreEqual(container_button2, actual);
        }
    }
}
