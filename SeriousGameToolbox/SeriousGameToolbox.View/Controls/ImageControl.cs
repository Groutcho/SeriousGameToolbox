using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ImageControl : Control
    {
        private Texture image;

        public ImageControl(Area area, Texture image) : base(area)
        {
            if (image != null)
            {
                this.image = image;
            }
        }

        protected override void DrawControl()
        {
            base.DrawControl();

            GUI.DrawTexture(Dimensions, image, ScaleMode.StretchToFill);
        }
    }
}
