using NUnit.Framework;
using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests
{
    [TestFixture]
    [Category("I2D")]
    [Category("WidgetContainer")]
    public class WidgetContainer_Tests
    {
        private class FakeWidget : Widget
        {
            public FakeWidget(Area area) : base(area)
            {

            }
        }

        [Test]
        public void Find_OneNestedWidget_ReturnsCorrectResult()
        {
            var screen = new ScreenWidget();
            screen.Name = "screen";

            float buttonWidth = 100;
            float buttonHeight = 40;

            var button1 = new FakeWidget(new Area(40, 40, buttonWidth, buttonHeight));
            button1.Name = "button1";

            var button2 = new FakeWidget(new Area(5 + 40, 40, buttonWidth, buttonHeight));
            button2.Name = "button2";

            var button3 = new FakeWidget(new Area(40, 5 + 40, buttonWidth, buttonHeight));
            button3.Name = "button3";

            var button4 = new FakeWidget(new Area(5 + 40, 5, buttonWidth, buttonHeight));
            button4.Name = "button4";

            var container = new BoxWidget(new Area(5 + 40, 5, 300, 300));
            container.Name = "container";

            var button5 = new FakeWidget(new Area(10, 10, buttonWidth, buttonHeight));
            button5.Name = "button1";

            var container_button2 = new FakeWidget(new Area(5 + 10, 10, buttonWidth, buttonHeight));
            container_button2.Name = "button2";

            container.AddWidget(button5);
            container.AddWidget(container_button2);

            screen.AddWidget(button1);
            screen.AddWidget(button2);
            screen.AddWidget(button3);
            screen.AddWidget(button4);

            screen.AddWidget(container);

            var actual = screen.Find("container/button2");

            Assert.AreEqual(container_button2, actual);
        }
    }
}
