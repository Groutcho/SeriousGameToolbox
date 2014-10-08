using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class FloatParameter : Parameter
    {
        protected float value;

        public override object GetValue()
        {
            return (object)value;
        }

        public FloatParameter(string id, string caption, float value)
            : base(id, caption)
        {
            this.value = value;
        }

        public static implicit operator float(FloatParameter p)
        {
            return p.value;
        }

        public override Parameter Clone()
        {
            return new FloatParameter(this.Id, this.Caption, this.value);
        }

        public override bool Equals(Parameter other)
        {
            if (other == this)
            {
                return true;
            }

            if (!(other is FloatParameter))
            {
                return false;
            }

            FloatParameter otherAs = other as FloatParameter;

            return (other.Id == Id && value == otherAs.value && other.Caption == Caption);
        }
    }
}
