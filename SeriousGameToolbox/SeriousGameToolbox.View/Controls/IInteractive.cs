using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Controls
{
    public delegate void ControlClickedEvent(int mouseButton);

    public interface IInteractive
    {
        event ControlClickedEvent Clicked;
    }
}
