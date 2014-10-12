using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class ScreenWidget : WidgetContainer
    {
        public ScreenWidget(GUISkin skin)
            : base(Area.None, skin)
        {

        }

        public ScreenWidget()
            : base(Area.None)
        {

        }

        protected override void OnDisplayChanged(UnityEngine.Resolution r)
        {
            base.OnDisplayChanged(r);

            area = new Area(0, 0, r.width, r.height);
        }
    }
}
