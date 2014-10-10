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

        public Decorator(Widget widget) : base(widget.Area)
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

        protected override void PrivateDraw()
        {
            base.PrivateDraw();

            widget.Draw();

            DrawDecorator();
        } 
    }
}
