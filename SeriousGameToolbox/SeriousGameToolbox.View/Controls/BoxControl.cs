using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class BoxControl : ControlContainer
    {
        public BoxControl(Area area) : base(area)
        {

        }

        protected override void DrawControl()
        {
            GUI.Box(Dimensions, GUIContent.none, Style);
            base.DrawControl();            
        }
    }
}
