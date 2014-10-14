using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Controls
{
    public class VerticalStack : ControlContainer
    {
        public VerticalStack(Area area)
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

            float cumulatedHeightOfAllControls = 0;

            foreach (var item in controls)
            {
                cumulatedHeightOfAllControls += item.Dimensions.Height;
            }

            float actualHeight = Dimensions.Height;
            float spacing = (actualHeight - cumulatedHeightOfAllControls) / (controls.Count - 1);
            float xOffset;

            Area r0 = controls[0].Area;
            xOffset = (area.Width - r0.Width) / 2;
            controls[0].Area = new Area(xOffset, 0, r0.Width, r0.Height);

            for (int i = 1; i < controls.Count; i++)
            {
                r0 = controls[i - 1].Area;
                var r1 = controls[i].Area;
                xOffset = (area.Width - r1.Width) / 2;
                controls[i].Area = new Area(xOffset, r0.Y + r0.Height + spacing, r1.Width, r1.Height);
            }
        }
    }
}
