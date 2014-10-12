using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class TextWidget : UnityWidget
    {
        public string Text { get; set; }

        public TextWidget(Area area, GUIStyle style, string text)
            : base(area, style)
        {
            if (text == null)
            {
                text = string.Empty;
            }
            this.Text = text;
            this.defaultStyle = style;
        }

        protected override void PrivateDraw(Area dimensions)
        {
            base.PrivateDraw(dimensions);

            GUI.Label(dimensions, Text, Style);
        }
    }
}
