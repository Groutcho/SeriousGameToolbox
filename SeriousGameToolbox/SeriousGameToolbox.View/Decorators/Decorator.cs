using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public abstract class Decorator : UnityWidget
    {
        public Decorator(Area area)
            : base(area, null)
        {

        }

        public Decorator(Area area, GUIStyle style) : base(area, style)
        {

        }

        public override void Draw()
        {
            if (!visible)
            {
                return;
            }
        }
    }
}
