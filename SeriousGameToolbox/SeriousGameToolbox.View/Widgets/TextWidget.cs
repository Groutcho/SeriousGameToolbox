using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class TextWidget : Widget
    {
        public string Text { get; set; }

        public TextWidget(Area area, string text)
            : base(area)
        {
            if (text == null)
            {
                text = string.Empty;
            }
            this.Text = text;
        }

        public TextWidget(Area area, GUISkin skin, string text)
            : base(area, skin)
        {
            if (text == null)
            {
                text = string.Empty;
            }
            this.Text = text;
            this.defaultStyle = skin.GetStyle("label");
        }

        protected override void PrivateDraw(Rect dimensions)
        {
            base.PrivateDraw(dimensions);

            GUI.Label(dimensions, Text, Style);
        }
    }
}
