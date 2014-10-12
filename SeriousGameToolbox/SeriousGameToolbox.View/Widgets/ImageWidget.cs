using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class ImageWidget : Widget
    {
        private Texture image;

        public ImageWidget(Area area, Texture image) : base(area)
        {
            if (image != null)
            {
                this.image = image;
            }
        }

        protected override void PrivateDraw(Area dimensions)
        {
            base.PrivateDraw(dimensions);

            GUI.DrawTexture(dimensions, image, ScaleMode.StretchToFill);
        }
    }
}
