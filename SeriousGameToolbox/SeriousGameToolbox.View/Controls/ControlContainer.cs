using SeriousGameToolbox.I2D.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Controls
{
    /// <summary>
    /// Base control for control containers.
    /// </summary>
    public class ControlContainer : Control
    {
        protected List<Control> controls;

        /// <summary>
        /// The Controls contained in this container.
        /// </summary>
        public ICollection<Control> Children
        {
            get { return controls; }
        }

        public ControlContainer(Area area)
            : base(area)
        {
            controls = new List<Control>(10);
        }

        public virtual void AddControl(Control control)
        {
            if (control == null)
            {
                throw new ArgumentNullException("control");
            }

            controls.Add(control);
            control.AbsoluteArea = new Area(AbsoluteArea.X + control.Area.X, AbsoluteArea.Y + control.Area.Y, control.Area.Width, control.Area.Height);
            control.EventBubbled += OnEventBubbled;
        }

        protected virtual void OnEventBubbled(ControlEvent e)
        {
            BubbleEvent(e);
        }

        protected override void DrawControl()
        {
            base.DrawControl();

            foreach (var item in controls)
            {
                item.Draw();
            }
        }

        /// <summary>
        /// Returns a child Control with the given path.
        /// </summary>
        /// <param name="xPath">the xPath to look for. For example, "control1/control2/control3". If null, will throw a NullArgumentException</param>
        /// <param name="from">The hierarchy to start looking for. For example, if xPath is "control1/control2/control3", and "from" is 1, the working xPath will be "control2/control3". If from is zero, the entire xPath is used.</param>
        /// <returns>Null if the Control has not been found. If the xPath is an empty string, will return the object from which it was called. The child Control in any other case.</returns>
        public virtual Control Find(string xPath, int from = 0)
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

            Control child = (Children.FirstOrDefault(w => w.Name == levels[from]));

            if (levels.Length - from == 1)
            {
                return child;
            }
            else if (child is ControlContainer)
            {
                var cc = child as ControlContainer;
                return cc.Find(xPath, from + 1);
            }

            return null;
        }
    }
}
