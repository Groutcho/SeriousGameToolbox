using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.I2D.Decorators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public abstract class Widget : IDrawable
    {
        private Resolution currentResolution;

        protected bool areaContainsMouse;
        protected GUISkin skin;
        public GUISkin Skin
        {
            get { return skin; }
            set { skin = value; }
        }
        protected Rect area;
        public Rect Area
        {
            get { return area; }
            set { area = value; }
        }

        protected GUIStyle defaultStyle;
        protected GUIStyle style;
        public GUIStyle Style
        {
            get
            {
                return style ?? defaultStyle;
            }
            set
            {
                if (value != null)
                {
                    style = value;
                }
            }
        }

        public Rect Dimensions
        {
            get { return new Rect(0, 0, area.width, area.height); }
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

        List<Decorator> rearDecorators = new List<Decorator>(2);
        public ICollection<Decorator> RearDecorators
        {
            get
            {
                return rearDecorators;
            }
            set
            {
                if (value == null)
                {
                    rearDecorators = new List<Decorator>(2);
                }
                else
                {
                    rearDecorators = new List<Decorator>(value);
                }
            }
        }

        List<Decorator> frontDecorators = new List<Decorator>(2);
        public ICollection<Decorator> FrontDecorators
        {
            get
            {
                return frontDecorators;
            }
            set
            {
                if (value == null)
                {
                    frontDecorators = new List<Decorator>(2);
                }
                else
                {
                    frontDecorators = new List<Decorator>(value);
                }
            }
        }

        public virtual void Draw()
        {
            if (!visible)
            {
                return;
            }

            CheckIfAreaContainsMouse();

            CheckForDisplayChange();

            DrawRearDecorators();

            GUI.BeginGroup(area);

            PrivateDraw(Dimensions);

            GUI.EndGroup();

            DrawFrontalDecorators();
        }

        private void DrawFrontalDecorators()
        {
            foreach (var item in frontDecorators)
            {
                item.area = area;
                item.Draw();
            }
        }

        private void DrawRearDecorators()
        {
            foreach (var item in rearDecorators)
            {
                item.area = area;
                item.Draw();
            }
        }

        private void CheckIfAreaContainsMouse()
        {
            Vector2 mouse = Event.current.mousePosition;

            areaContainsMouse = area.Contains(mouse);
        }

        private void CheckForDisplayChange()
        {
            if (Screen.width != currentResolution.height || Screen.height != currentResolution.width)
            {
                currentResolution = new Resolution() { width = Screen.width, height = Screen.height };

                OnDisplayChanged(currentResolution);
            }
        }

        protected virtual void OnDisplayChanged(Resolution newResolution)
        {
        }

        protected virtual void PrivateDraw(Rect dimensions)
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
        }

        public Widget(Rect area, GUISkin skin)
        {
            this.area = area;

            if (skin == null)
            {
                throw new System.ArgumentNullException("skin");
            }
            this.skin = skin;
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

        public static Rect GetDockedRect(Rect container, Vector2 dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            float x = 0;
            float y = 0;

            float dw2 = dimensions.x / 2;
            float dh2 = dimensions.y / 2;
            float sw2 = container.width / 2;
            float sh2 = container.height / 2;

            float deltaX = container.x;
            float deltaY = container.y;

            switch (vAlign)
            {
                case VerticalAlignment.Center: y = sh2 - dh2;
                    break;
                case VerticalAlignment.Top: y = margin;
                    break;
                case VerticalAlignment.Bottom: y = Screen.height - margin - dimensions.y;
                    break;
            }

            switch (hAlign)
            {
                case HorizontalAlignement.Center: x = sw2 - dh2;
                    break;
                case HorizontalAlignement.Left: x = margin;
                    break;
                case HorizontalAlignement.Right: x = Screen.width - dimensions.x - margin;
                    break;
            }

            return new Rect(x + deltaX, y + deltaY, dimensions.x, dimensions.y);
        }

        public static Rect GetDockedRect(Vector2 dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            Rect screen = new Rect(0, 0, Screen.width, Screen.height);
            return GetDockedRect(screen, dimensions, hAlign, vAlign, margin);
        }
    }
}
