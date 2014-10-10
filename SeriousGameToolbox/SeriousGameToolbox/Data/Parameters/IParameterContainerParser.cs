using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public interface IParameterContainerParser
    {
        void Save(ParameterContainer container);
        ParameterContainer Parse(string content);
    }
}
