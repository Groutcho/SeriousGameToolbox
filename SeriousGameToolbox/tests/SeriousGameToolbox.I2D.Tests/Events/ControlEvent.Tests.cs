using NUnit.Framework;
using SeriousGameToolbox.I2D.Controls;
using SeriousGameToolbox.I2D.Tests.Controls.Fakes;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests.Events
{
    [TestFixture]
    [Category("I2D")]
    [Category("Events")]
    public class ControlEvent_Tests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ControlEvent_NullSender_ThrowsArgumentNullException()
        {
            new FakeControlEvent(Deliberate.Null as Control);
        }

        [Test]
        public void ControlEvent_Constructor_SetsSender()
        {
            Control expected = new TextControl(Area.None, string.Empty);
            var eve = new FakeControlEvent(expected);

            Assert.AreSame(expected, eve.Sender);
        }
    }
}
