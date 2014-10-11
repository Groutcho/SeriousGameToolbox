
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class HorizontalStack : WidgetContainer
    {
        private Rect padding;
        public Rect Padding
        {
            get { return padding; }
            set
            {
                if (padding != value)
                {
                    padding = value;
                    RecomputeAreas();
                }
            }
        }

        public HorizontalStack(Rect area, GUISkin skin)
            : base(area, skin)
        {
        }

        public override void AddWidget(Widget widget)
        {
            base.AddWidget(widget);
            RecomputeAreas();
        }

        private void RecomputeAreas()
        {
            if (widgets.Count == 0)
            {
                return;
            }

            Rect r = widgets[0].Area;
            widgets[0].Area = new Rect(padding.x, padding.y, r.width, r.height);

            for (int i = 1; i < widgets.Count; i++)
            {
                r = widgets[i-1].Area;
                widgets[i].Area = new Rect(r.xMax + padding.x, padding.y, r.width, r.height);
            }
        }
    }
}
