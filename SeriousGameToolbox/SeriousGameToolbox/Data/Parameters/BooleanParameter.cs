using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class BooleanParameter : Parameter
    {
        private bool value;

        public override object GetValue()
        {
            return (object)value;
        }

        public BooleanParameter(string id, string caption, bool value)
            : base(id, caption)
        {
            this.value = value;
        }

        public static implicit operator bool(BooleanParameter b)
        {
            return b.value;
        }

        public override Parameter Clone()
        {
            return new BooleanParameter(this.Id, this.Caption, this.value);
        }


    }
}
