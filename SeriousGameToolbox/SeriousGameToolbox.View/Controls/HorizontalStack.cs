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
                if (!padding.Equals(value))
                {
                    padding = value;
                    RecomputeSpacingBetweenControls();
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
            RecomputeSpacingBetweenControls();
        }

        private void RecomputeSpacingBetweenControls()
        {
            if (controls.Count == 0)
            {
                return;
            }

            float cumulatedWidthOfAllControls = 0;

            foreach (var item in controls)
            {
                cumulatedWidthOfAllControls += item.Dimensions.Width;
            }

            float actualWidth = Dimensions.Width - padding.X - padding.Height;
            float spacing = (actualWidth - cumulatedWidthOfAllControls) / (controls.Count - 1);

            Area r = controls[0].Area;
            controls[0].Area = new Area(padding.X, padding.Y, r.Width, r.Height);

            for (int i = 1; i < controls.Count; i++)
            {
                r = controls[i - 1].Area;
                controls[i].Area = new Area(r.X + r.Width + spacing, padding.Y, r.Width, r.Height);
            }
        }
    }
}
