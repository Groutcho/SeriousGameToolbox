using SeriousGameToolbox.I2D.Controls;
using SeriousGameToolbox.I2D.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests.Controls.Fakes
{
    internal class FakeControlEvent : ControlEvent
    {
        public FakeControlEvent(Control sender)
            : base(sender)
        {

        }
    }
}
