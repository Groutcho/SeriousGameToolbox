using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class ImageWidget : Widget
    {
        private Texture image;

        public ImageWidget(Rect area, Texture image) : base(area)
        {
            if (image != null)
            {
                this.image = image;
            }
        }

        protected override void PrivateDraw()
        {
            base.PrivateDraw();

            GUI.DrawTexture(area, image);
        }
    }
}
