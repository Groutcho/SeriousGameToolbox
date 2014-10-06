using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class BooleanParameter : Parameter
    {
        public new bool Value { get; set; }

        public BooleanParameter(string id, string caption, bool current)
            : base(id, caption)
        {
            this.Value = current;
        }

        public static implicit operator bool(BooleanParameter b)
        {
            return b.Value;
        }

        public override Parameter Clone()
        {
            return new BooleanParameter(this.Id, this.Caption, this.Value);
        }
    }
}
