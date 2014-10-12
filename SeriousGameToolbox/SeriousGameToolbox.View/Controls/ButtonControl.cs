using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ButtonControl : UnityControl, IInteractive
    {
        GUIContent content;

        public ButtonControl(Area area, GUIContent content, GUIStyle style)
            : base(area, style)
        {
            if (content != null)
            {
                this.content = content;
            }        
        }

        protected override void PrivateDraw(Area dimensions)
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

        public event ControlClickedEvent Clicked;
    }
}
