using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Controls
{
    public class HorizontalStack : ControlContainer
    {
        private Area padding = Area.None;
        public Area Padding
        {
            get { return padding; }
            set
            {
                if (value != null && padding != value)
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

        public override void AddControl(Control Control)
        {
            base.AddControl(Control);
            RecomputeAreas();
        }

        private void RecomputeAreas()
        {
            if (controls.Count == 0)
            {
                return;
            }

            Area r = controls[0].Area;
            controls[0].Area = new Area(padding.X, padding.Y, r.Width, r.Height);

            for (int i = 1; i < controls.Count; i++)
            {
                r = controls[i - 1].Area;
                controls[i].Area = new Area(r.X + r.Width + padding.X, padding.Y, r.Width, r.Height);
            }
        }
    }
}
