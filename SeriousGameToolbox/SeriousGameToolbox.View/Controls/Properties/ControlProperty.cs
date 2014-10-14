using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I2D.Controls.Properties
{
    public abstract class ControlProperty
    {
        public bool Enabled { get; set; }

        public void Update2d()
        {
            if (Enabled)
            {
                Apply();
            }
        }

        protected abstract void Apply();
    }
}
