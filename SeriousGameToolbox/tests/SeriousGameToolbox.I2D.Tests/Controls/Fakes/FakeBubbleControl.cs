﻿using SeriousGameToolbox.I2D.Controls;
using SeriousGameToolbox.I2D.Events;
using SeriousGameToolbox.Tests._utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGameToolbox.I2D.Tests.Controls.Fakes
{
    internal class FakeBubbleControl : Control
    {
        public FakeBubbleControl()
            : base(Area.None)
        {

        }

        public void TriggerEvent()
        {
            BubbleEvent(new FakeControlEvent(this));
        }

        public void TriggerNullEvent()
        {
            BubbleEvent(Deliberate.Null as ControlEvent);
        }
    }
}
