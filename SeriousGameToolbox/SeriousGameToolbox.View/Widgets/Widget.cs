using SeriousGameToolbox.Contracts;
using UnityEngine;

namespace SeriousGameToolbox.View.Widgets
{
    public abstract class Widget : IDrawable
    {
        protected GUISkin skin;
        protected Rect area;
        public Rect Area
        {
            get { return area; }
            set { area = value; }
        }

        protected Rect dimensions;
        public Rect Dimensions
        {
            get { return dimensions; }
        }

        protected bool visible;
        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
            }
        }

        public virtual void Draw()
        {
            if (!visible)
            {
                return;
            }

            PrivateDraw();
        }

        protected virtual void PrivateDraw()
        {
        }

        public void Show()
        {
            visible = true;
        }

        public void Hide()
        {
            visible = false;
        }

        public Widget(Rect area)
        {
            this.area = area;
            this.dimensions = new Rect(0, 0, area.width, area.height);
        }
    }
}
