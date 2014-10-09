using SeriousGameToolbox.View.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.View.Decorators
{
    public class FrameDecorator : Decorator
    {
        public FrameDecorator(Widget widget) : base(widget)
        {

        }

        protected override void DrawDecorator()
        {
            GUI.Box(area, GUIContent.none);
        }
    }
}
