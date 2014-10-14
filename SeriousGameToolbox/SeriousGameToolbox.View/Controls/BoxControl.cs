using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class BoxControl : Control
    {
        public BoxControl(Area area) : base(area)
        {

        }

        protected override void DrawControl()
        {
            base.DrawControl();  
            GUI.Box(Dimensions, GUIContent.none, Style);                      
        }
    }
}
