using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class TextControl : Control
    {
        public string Text { get; set; }

        public TextControl(Area area, string text)
            : base(area)
        {
            if (text == null)
            {
                text = string.Empty;
            }
            this.Text = text;
        }

        protected override void DrawControl()
        {
            base.DrawControl();

            GUI.Label(Dimensions, Text, Style);
        }
    }
}
