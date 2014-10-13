using SeriousGameToolbox.I2D.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Events
{
    public class ControlClickedEvent : ControlEvent
    {
        public int Button { get; protected set; }

        public ControlClickedEvent(Control sender, int button)
            : base(sender)
        {
            this.Button = button;
        }
    }
}
