using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class IntegerParameter : Parameter
    {
        public new virtual int Value { get; set; }

        public IntegerParameter(string id, string caption, int current)
            : base(id, caption)
        {
            this.Value = current;
        }

        public static implicit operator int(IntegerParameter p)
        {
            return p.Value;
        }

        public override Parameter Clone()
        {
            return new IntegerParameter(this.Id, this.Caption, this.Value);
        }
    }
}
