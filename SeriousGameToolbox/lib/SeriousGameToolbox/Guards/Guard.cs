using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Guards
{
    public static class Guard
    {
        public static void AgainstNullArgument(string name, object arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(name);
            }
        }        
    }
}
