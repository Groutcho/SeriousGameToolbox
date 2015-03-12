using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls.Properties
{
    /// <summary>
    /// Applies a sinusoidal variation of opacity.
    /// </summary>
    public class Blink : ControlProperty
    {
        float f = 0;

        protected override void Apply()
        {
            f += Time.deltaTime * 4;
            var c = GUI.color;
            c.a = (Mathf.Sin(f) + 1) / 2;
            GUI.color = c;
        }
    }
}
