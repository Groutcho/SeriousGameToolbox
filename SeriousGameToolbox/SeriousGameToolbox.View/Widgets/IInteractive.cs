using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Widgets
{
    public delegate void WidgetClickedEvent(int mouseButton);

    public interface IInteractive
    {
        event WidgetClickedEvent Clicked;
    }
}
