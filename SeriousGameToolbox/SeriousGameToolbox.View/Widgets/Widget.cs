using SeriousGameToolbox.Contracts;
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

        public virtual void Draw()
        {
            if (!visible)
            {
                return;
            }

            CheckIfAreaContainsMouse();

            CheckForDisplayChange();

            GUI.BeginGroup(area);

            PrivateDraw(Dimensions);

            GUI.EndGroup();
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
                currentResolution = new Resolution() { width = Screen.width, height=Screen.height};

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
    }
}
