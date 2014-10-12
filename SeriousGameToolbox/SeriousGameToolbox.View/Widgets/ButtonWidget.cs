using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class ButtonWidget : Widget, IInteractive
    {
        GUIContent content;

        public ButtonWidget(Area area, string text, GUISkin skin)
            : this(area, new GUIContent(text), skin) {}

        public ButtonWidget(Area area, GUIContent content, GUISkin skin)
            : base(area, skin)
        {
            if (content != null)
            {
                this.content = content;
            }

            if (skin != null)
            {
                this.defaultStyle = skin.GetStyle("button");
            }           
        }

        protected override void PrivateDraw(UnityEngine.Rect dimensions)
        {
            base.PrivateDraw(dimensions);

            if (GUI.Button(dimensions, content, Style))
            {
                if (Clicked != null)
                {
                    Clicked(Event.current.button);
                }
            }
        }

        public event WidgetClickedEvent Clicked;
    }
}
