using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public class ScrollbarDecorator : Decorator
    {
        public float Thickness { get; set; }

        float hValue;
        const float size = 100;

        public ScrollbarDecorator(Area area, GUISkin skin)
            : base(area, skin)
        {

        }

        public override void Draw()
        {
            base.Draw();

            Rect ar = area;
            hValue = GUI.HorizontalScrollbar(new Rect(ar.x, ar.yMax - Thickness, ar.width, Thickness), hValue, 1f, 0, 10f);
        }
    }
}
