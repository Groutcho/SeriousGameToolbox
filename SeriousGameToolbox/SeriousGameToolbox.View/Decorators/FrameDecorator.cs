using SeriousGameToolbox.I2D.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public class FrameDecorator : Decorator
    {
        public FrameDecorator(Area area)
            : base(area)
        {
        }

        public override void Draw()
        {
            base.Draw();
            GUI.Box(Area, GUIContent.none, Style);
        }
    }
}
