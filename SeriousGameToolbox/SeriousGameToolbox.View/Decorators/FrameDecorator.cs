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
        public FrameDecorator(Area area, GUISkin skin)
            : base(area, skin)
        {
            this.defaultStyle = skin.GetStyle("frame");
        }

        public override void Draw()
        {
            base.Draw();
            GUI.Box(area, GUIContent.none, Style);
        }
    }
}
