using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Texts
{
    public interface ITextContainerParser
    {
        TextContainer Parse(string content);
    }
}
