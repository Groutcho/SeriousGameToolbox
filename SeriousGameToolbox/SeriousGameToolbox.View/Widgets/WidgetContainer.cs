using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Widgets
{
    public class WidgetContainer : Widget
    {
        protected List<Widget> widgets;

        /// <summary>
        /// The widgets contained in this container.
        /// </summary>
        public ICollection<Widget> Widgets
        {
            get { return widgets; }
        }

        /// <summary>
        /// Returns a child widget with the given path.
        /// </summary>
        /// <param name="xPath">the xPath to look for. For example, "myContainer/mySubContainer/myWidget". If null, will throw a NullArgumentException</param>
        /// <param name="from">the level to start looking for. For example, if xPath is "myContainer/mySubContainer/myWidget", and "from" is 1, the working xPath will be "mySubContainer/myWidget". If from is zero, the xPath is not altered.</param>
        /// <returns>Null if the widget has not been found. If the xPath is an empty string, will return the object from which it was called. The child widget in any other case.</returns>
        public Widget Find(string xPath, int from = 0)
        {
            if (xPath == null)
            {
                throw new ArgumentNullException("xPath");
            }

            if (xPath == string.Empty)
            {
                return this;
            }

            string[] levels = xPath.Split('/');

            Widget child = (widgets.FirstOrDefault(w => w.Name == levels[from]));

            if (levels.Length - from == 1)
            {
                return child;
            }
            else if (child is WidgetContainer)
            {
                var cc = child as WidgetContainer;
                return cc.Find(xPath, from + 1);
            }

            return null;
        }

        public WidgetContainer(Area area)
            : base(area)
        {
            widgets = new List<Widget>(10);
        }

        public virtual void AddWidget(Widget widget)
        {
            if (widget == null)
            {
                throw new ArgumentNullException("widget");
            }

            widgets.Add(widget);
        }

        protected override void PrivateDraw(Area dimensions)
        {
            base.PrivateDraw(dimensions);

            foreach (var item in widgets)
            {
                item.Draw();
            }
        }
    }
}
