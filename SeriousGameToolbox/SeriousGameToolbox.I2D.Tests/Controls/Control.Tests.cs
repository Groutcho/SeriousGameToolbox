using NUnit.Framework;
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
    public class Control_Tests
    {
        [Test]
        public void Contructor_ValidArea_SetsAreaProperty()
        {
            var area = new Area(10, 10, 200, 200);
            var ctrl = new FakeControl(area);

            Assert.AreEqual(area, ctrl.Area);
        }

        [Test]
        public void Dimensions_AreValid()
        {
            var area = new Area(10, 10, 200, 200);
            var ctrl = new FakeControl(area);

            var expectedDimensions = new Area(0, 0, area.Width, area.Height);

            Assert.AreEqual(expectedDimensions, ctrl.Dimensions);
        }

        [Test]
        public void Visible_Is_True_By_Default()
        {
            var ctrl = new FakeControl(Area.None);

            Assert.IsTrue(ctrl.Visible);
        }

        [Test]
        public void DecoratorCollections_Are_Never_Null()
        {
            var ctrl = new FakeControl(Area.None);

            Assert.IsNotNull(ctrl.RearDecorators);
            Assert.IsNotNull(ctrl.FrontDecorators);

            ctrl.RearDecorators = null;
            ctrl.FrontDecorators = null;

            Assert.IsNotNull(ctrl.RearDecorators);
            Assert.IsNotNull(ctrl.FrontDecorators);
        }
    }
}
