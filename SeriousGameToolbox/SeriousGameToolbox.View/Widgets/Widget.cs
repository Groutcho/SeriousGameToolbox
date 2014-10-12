using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.I2D.Decorators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public abstract class Widget : IDrawable
    {
        protected Area area;
        public Area Area
        {
            get { return area; }
            set { area = value; }
        }

        public Area Dimensions
        {
            get { return new Area(0, 0, area.Width, area.Height); }
        }

        protected bool visible = true;
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

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }

        public virtual void Draw()
        {
            if (!visible)
            {
                return;
            }

        }

        protected virtual void PrivateDraw(Area dimensions)
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

        public Widget(Area area)
        {
            this.area = area;
        }

        public enum HorizontalAlignement
        {
            Center,
            Left,
            Right
        }

        public enum VerticalAlignment
        {
            Center,
            Top,
            Bottom
        }

        public static Area GetDockedRect(Area container, UnityEngine.Vector2 dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            float x = 0;
            float y = 0;

            float dw2 = dimensions.x / 2;
            float dh2 = dimensions.y / 2;
            float sw2 = container.Width / 2;
            float sh2 = container.Height / 2;

            float deltaX = container.X;
            float deltaY = container.X;

            switch (vAlign)
            {
                case VerticalAlignment.Center: y = sh2 - dh2;
                    break;
                case VerticalAlignment.Top: y = margin;
                    break;
                case VerticalAlignment.Bottom: y = UnityEngine.Screen.height - margin - dimensions.y;
                    break;
            }

            switch (hAlign)
            {
                case HorizontalAlignement.Center: x = sw2 - dh2;
                    break;
                case HorizontalAlignement.Left: x = margin;
                    break;
                case HorizontalAlignement.Right: x = UnityEngine.Screen.width - dimensions.x - margin;
                    break;
            }

            return new Area(x + deltaX, y + deltaY, dimensions.x, dimensions.y);
        }

        public static Area GetDockedRect(UnityEngine.Vector2 dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            Area screen = new Area(0, 0, Screen.width, Screen.height);
            return GetDockedRect(screen, dimensions, hAlign, vAlign, margin);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", name, GetType());
        }

        protected virtual void OnDisplayChanged(Vector2 newResolution)
        {
        }
    }
}
