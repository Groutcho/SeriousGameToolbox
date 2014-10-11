using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class WidgetContainer : Widget
    {
        List<Widget> widgets;

        public WidgetContainer(Rect area, GUISkin skin)
            : base(area, skin)
        {
            widgets = new List<Widget>(10);
        }

        public void AddWidget(Widget widget)
        {
            if (widget == null)
            {
                throw new ArgumentNullException("widget");
            }

            widgets.Add(widget);
        }

        protected override void PrivateDraw(Rect dimensions)
        {
            base.PrivateDraw(dimensions);

            foreach (var item in widgets)
            {
                item.Draw();
            }
        }
    }
}
