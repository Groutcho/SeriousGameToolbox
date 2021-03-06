﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class FloatRangeParameter : FloatParameter
    {
        public float Minimum { get; private set; }
        public float Maximum { get; private set; }

        public FloatRangeParameter(string id, string caption, float min, float max, float value)
            : base(id, caption, value)
        {
            this.Minimum = min;
            this.Maximum = max;
        }

        public static implicit operator float(FloatRangeParameter p)
        {
            return p.value;
        }

        public override Parameter Clone()
        {
            return new FloatRangeParameter(this.Id, this.Caption, this.Minimum, this.Maximum, this.value);
        }

        public override bool Equals(Parameter other)
        {
            if (other == this)
            {
                return true;
            }

            if (!(other is FloatRangeParameter))
            {
                return false;
            }

            FloatRangeParameter otherAs = other as FloatRangeParameter;

            return (other.Id == Id && value == otherAs.value && other.Caption == Caption && otherAs.Maximum == Maximum && otherAs.Minimum == Minimum);
        }
    }
}
