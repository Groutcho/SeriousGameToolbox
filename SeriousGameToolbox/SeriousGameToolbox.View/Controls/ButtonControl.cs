using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ButtonControl : Control, IInteractive
    {
        public GUIContent GuiContent { get; set; }

        public ButtonControl(Area area)
            : base(area) { }

        protected override void DrawControl()
        {
            base.DrawControl();

            if (Style == null)
            {
                throw new NullReferenceException("The style for the control " + Name + " is missing.");
            }

            if (GuiContent == null)
            {
                throw new NullReferenceException("The GuiContent for the control " + Name + " is missing.");
            }

            if (GUI.Button(Dimensions, GuiContent, Style))
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
