using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public class FrameDecorator : Decorator
    {
        public FrameDecorator(Widget widget, GUISkin skin)
            : base(widget, skin)
        {

        }

        protected override void DrawDecorator()
        {
            GUI.Box(area, GUIContent.none);
        }
    }
}
