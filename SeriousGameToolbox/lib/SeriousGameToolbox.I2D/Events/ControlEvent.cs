﻿using SeriousGameToolbox.I2D.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Events
{
    public abstract class ControlEvent
    {
        Control sender;
        public Control Sender { get { return sender; } }

        public ControlEvent(Control sender)
        {
            Guards.Guard.AgainstNullArgument("sender", sender);
            this.sender = sender;
        }
    }
}
