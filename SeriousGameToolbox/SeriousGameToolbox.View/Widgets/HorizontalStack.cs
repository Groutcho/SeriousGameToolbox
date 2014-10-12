using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class HorizontalStack : WidgetContainer
    {
        private Area padding;
        public Area Padding
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

        public HorizontalStack(Area area)
            : base(area)
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

            Area r = widgets[0].Area;
            widgets[0].Area = new Area(padding.X, padding.Y, r.Width, r.Height);

            for (int i = 1; i < widgets.Count; i++)
            {
                r = widgets[i - 1].Area;
                widgets[i].Area = new Area(r.X + r.Width + padding.X, padding.Y, r.Width, r.Height);
            }
        }
    }
}
