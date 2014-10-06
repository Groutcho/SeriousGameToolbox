using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class FloatRangeParameter : FloatParameter
    {
        public float Minimum { get; private set; }
        public float Maximum { get; private set; }

        public FloatRangeParameter(string id, string caption, float min, float max, float current)
            : base(id, caption, current)
        {
            this.Minimum = min;
            this.Maximum = max;
        }

        public static implicit operator float(FloatRangeParameter p)
        {
            return p.Value;
        }

        public override Parameter Clone()
        {
            return new FloatRangeParameter(this.Id, this.Caption, this.Minimum, this.Maximum, this.current);
        }
    }
}
