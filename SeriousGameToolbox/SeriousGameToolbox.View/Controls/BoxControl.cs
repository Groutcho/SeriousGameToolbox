using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class BoxControl : ControlContainer
    {
        private GUIStyle style;

        public BoxControl(Area area) : base(area)
        {

        }
        public BoxControl(Area area, GUIStyle style)
            : base(area)
        {
            this.style = style;
        }

        protected override void PrivateDraw(Area dimensions)
        {
            GUI.Box(dimensions, GUIContent.none, style);
            base.PrivateDraw(dimensions);            
        }
    }
}
