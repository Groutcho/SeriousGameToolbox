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
        public bool Blink { get; set; }

        float f;

        public FrameDecorator(Area area)
            : base(area)
        {
            f = 0;
        }

        public override void Draw()
        {
            base.Draw();

            if (!visible)
            {
                return;
            }

            if (Blink)
            {
                f += Time.deltaTime * 4;
                var c = GUI.color;
                c.a = (Mathf.Sin(f) + 1) / 2;
                GUI.color = c;
            }

            GUI.Box(Area, GUIContent.none, Style);
        }
    }
}
