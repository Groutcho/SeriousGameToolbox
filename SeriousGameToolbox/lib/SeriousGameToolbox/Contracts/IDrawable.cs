using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Contracts
{
    public interface IDrawable
    {
        bool Visible { get; set; }
        void Draw();
        void Show();
        void Hide();
    }
}
