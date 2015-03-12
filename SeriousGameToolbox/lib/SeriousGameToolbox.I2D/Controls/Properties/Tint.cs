using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls.Properties
{
    /// <summary>
    /// Tints the control.
    /// </summary>
    public class Tint : ControlProperty
    {
        public Color Value { get; set; }

        protected override void Apply()
        {
            Color c = GUI.color;

            c.r = Value.r;
            c.g = Value.g;
            c.b = Value.b;

            GUI.color = c;
        }
    }
}
