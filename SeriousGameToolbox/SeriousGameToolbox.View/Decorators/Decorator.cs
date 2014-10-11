using SeriousGameToolbox.I2D.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public abstract class Decorator : Widget
    {
        Widget widget;

        public Decorator(Widget widget, GUISkin skin)
            : base(widget.Area, skin)
        {
            if (widget == null)
            {
                throw new ArgumentNullException("widget");
            }

            this.widget = widget;
        }

        protected virtual void DrawDecorator()
        {
           
        }

        protected override void PrivateDraw(Rect dimensions)
        {
            base.PrivateDraw(dimensions);

            widget.Draw();
            DrawDecorator();
        } 
    }
}
