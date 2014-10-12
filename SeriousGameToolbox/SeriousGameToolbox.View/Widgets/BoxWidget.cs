using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class BoxWidget : WidgetContainer
    {
        private GUIStyle style;

        public BoxWidget(Area area) : base(area)
        {

        }
        public BoxWidget(Area area, GUIStyle style)
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
