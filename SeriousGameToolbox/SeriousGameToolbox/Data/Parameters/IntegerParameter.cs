using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class IntegerParameter : Parameter
    {
        protected int value;

        public override object GetValue()
        {
            return (object)value;
        }

        public IntegerParameter(string id, string caption, int current)
            : base(id, caption)
        {
            this.value = current;
        }

        public static implicit operator int(IntegerParameter p)
        {
            return p.value;
        }

        public override Parameter Clone()
        {
            return new IntegerParameter(this.Id, this.Caption, this.value);
        }
    }
}
