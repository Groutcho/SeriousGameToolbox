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
            : base(new Rect(0, 0, UnityEngine.Screen.width, UnityEngine.Screen.height), skin)
        {

        }

        protected override void OnDisplayChanged(UnityEngine.Resolution r)
        {
            base.OnDisplayChanged(r);

            area = new UnityEngine.Rect(0, 0, r.width, r.height);
        }
    }
}
