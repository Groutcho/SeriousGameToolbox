using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public abstract class Decorator : Widget
    {
        public Decorator(Area area) : base(area)
        {

        }

        public Decorator(Area area, GUISkin skin)
            : base(area, skin)
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
