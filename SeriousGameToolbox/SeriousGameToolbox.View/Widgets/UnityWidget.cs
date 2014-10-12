using SeriousGameToolbox.I2D.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Controls
{
    public class UnityWidget : Widget
    {
        private Vector2 currentResolution;
        protected bool areaContainsMouse;
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

        public UnityWidget(Area area, GUIStyle style) : base(area)
        {
            this.defaultStyle = style;
        }

        private void CheckIfAreaContainsMouse()
        {
            UnityEngine.Vector2 mouse = UnityEngine.Event.current.mousePosition;
            UnityEngine.Rect r = area;
            areaContainsMouse = r.Contains(mouse);
        }

        public override void Draw()
        {
            base.Draw();

            CheckIfAreaContainsMouse();

            //CheckForDisplayChange();

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
    }
}
