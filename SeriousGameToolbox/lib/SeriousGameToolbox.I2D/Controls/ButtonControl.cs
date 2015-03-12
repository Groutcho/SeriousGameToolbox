using SeriousGameToolbox.I2D.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ButtonControl : Control
    {
        private GUIContent guiContent = GUIContent.none;
        public GUIContent GuiContent
        {
            get { return guiContent; }

            set
            {
                if (value != null)
                {
                    guiContent = value;
                }
            }
        }

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
                BubbleEvent(new ControlClickedEvent(this, 0));
            }
        }
    }
}
