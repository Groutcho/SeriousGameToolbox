using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    /// <summary>
    /// A control that resizes itself automatically to fill the entire screen.
    /// </summary>
    public class ScreenControl : ControlContainer
    {
        public ScreenControl()
            : base(Area.None)
        {

        }

        protected override void OnDisplayChanged(float width, float height)
        {
            base.OnDisplayChanged(width, height);

            Area = new Area(0, 0, width, height);
        }
    }
}
