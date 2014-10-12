using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class BoxWidget : WidgetContainer
    {
        public BoxWidget(Area area) : base(area)
        {

        }
        public BoxWidget(Area area, GUISkin skin)
            : base(area, skin)
        {
            this.defaultStyle = skin.GetStyle("box");
        }

        protected override void PrivateDraw(Rect dimensions)
        {
            GUI.Box(dimensions, GUIContent.none, Style);
            base.PrivateDraw(dimensions);            
        }
    }
}
