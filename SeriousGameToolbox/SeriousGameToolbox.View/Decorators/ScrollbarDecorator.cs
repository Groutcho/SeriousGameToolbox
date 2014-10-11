﻿using SeriousGameToolbox.I2D.Widgets;
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

        public ScrollbarDecorator(Widget widget, GUISkin skin)
            : base(widget, skin)
        {

        }

        protected override void DrawDecorator()
        {
            hValue = GUI.HorizontalScrollbar(new Rect(area.x, area.yMax - Thickness, area.width, Thickness), hValue, 1f, 0, 10f);
        }
    }
}
