using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ScreenWidget : WidgetContainer
    {
        public ScreenWidget()
            : base(Area.None)
        {

        }

        protected override void OnDisplayChanged(Vector2 r)
        {
            base.OnDisplayChanged(r);

            area = new Area(0, 0, r.x, r.y);
        }
    }
}
