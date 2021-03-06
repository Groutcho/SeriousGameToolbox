﻿using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.I2D.Controls.Properties;
using SeriousGameToolbox.I2D.Decorators;
using SeriousGameToolbox.I2D.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public delegate void BubbledEventBubbled(ControlEvent e);

    /// <summary>
    /// Base class for all controls.
    /// </summary>
    public abstract class Control : IDrawable
    {
        protected Area area = Area.None;
        protected bool visible = true;
        private string name = string.Empty;

        private Area absoluteArea = Area.None;
        public Area AbsoluteArea
        {
            get { return absoluteArea; }
            set
            {
                absoluteArea = value;
            }
        }

        public Area Area
        {
            get { return area; }
            set { area = value; }
        }
        public Area Dimensions
        {
            get { return new Area(0, 0, area.Width, area.Height); }
        }

        private float rotation;
        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        private static Resolution resolution;

        public static ICollection<Control> Controls = new List<Control>(25);

        public GUIStyle Style { get; set; }

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

        private List<ControlProperty> properties = new List<ControlProperty>();
        public ICollection<ControlProperty> Properties
        {
            get { return properties; }
        }

        public static Area GetDockedArea(Area container, Area dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            float x = 0;
            float y = 0;

            float dw2 = dimensions.X / 2;
            float dh2 = dimensions.Y / 2;
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
                case VerticalAlignment.Bottom: y = container.Height - margin - dimensions.Y;
                    break;
            }

            switch (hAlign)
            {
                case HorizontalAlignement.Center: x = sw2 - dh2;
                    break;
                case HorizontalAlignement.Left: x = margin;
                    break;
                case HorizontalAlignement.Right: x = container.Width - dimensions.X - margin;
                    break;
            }

            return new Area(x + deltaX, y + deltaY, dimensions.X, dimensions.Y);
        }

        public static Area GetDockedArea(Area dimensions, HorizontalAlignement hAlign, VerticalAlignment vAlign, float margin = 0)
        {
            Area screen = new Area(0, 0, resolution.width, resolution.height);
            return GetDockedArea(screen, dimensions, hAlign, vAlign, margin);
        }

        public Control(Area area)
        {
            this.area = area;
            Controls.Add(this);
        }

        public virtual void Draw()
        {
            if (!visible)
            {
                return;
            }

            CheckForDisplayChange();

            CheckIfAreaContainsMouse();

            DrawRearDecorators();

            // note that BeginGroup will clip the content. That is why we put the decorators outside, since
            // some decorators need to draw outside the area. For instance, a frame.
            GUI.BeginGroup(area);

            GUI.color = Color.white;

            foreach (ControlProperty property in properties)
            {
                property.Update2d();
            }

            GUIUtility.RotateAroundPivot(rotation, Dimensions.Center);

            DrawControl();

            GUI.EndGroup();

            DrawFrontalDecorators();
        }

        private void CheckForDisplayChange()
        {
            var res = Screen.currentResolution;

            if (res.width != resolution.width || res.height != resolution.height)
            {
                OnDisplayChanged(res.width, res.height);
                resolution = res;
            }
        }

        protected List<Decorator> rearDecorators = new List<Decorator>(2);
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

        protected List<Decorator> frontDecorators = new List<Decorator>(2);
        protected bool areaContainsMouse;
        public virtual bool ContainsMouse { get { return areaContainsMouse; } }
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

        private void CheckIfAreaContainsMouse()
        {
            UnityEngine.Vector2 mouse = UnityEngine.Event.current.mousePosition;
            UnityEngine.Rect r = area;
            areaContainsMouse = r.Contains(mouse);
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

        public virtual void Show()
        {
            visible = true;
        }

        public virtual void Hide()
        {
            visible = false;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", name, GetType());
        }

        protected virtual void DrawControl()
        {
        }

        protected virtual void OnDisplayChanged(float width, float height)
        {
        }

        protected void BubbleEvent(ControlEvent bubbledEvent)
        {
            if (bubbledEvent == null)
            {
                throw new ArgumentNullException("bubbledEvent");
            }

            if (EventBubbled != null)
            {
                EventBubbled(bubbledEvent);
            }
        }

        public event BubbledEventBubbled EventBubbled;
    }
}
