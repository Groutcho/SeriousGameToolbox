using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class IntRangeParameter : IntegerParameter
    {
        public int Minimum { get; private set; }
        public int Maximum { get; private set; }

        private int current;
        public override int Value
        {
            get { return current; }
            set
            {
                if (value < Minimum)
                {
                    current = Minimum;
                }
                else if (value > Maximum)
                {
                    current = Maximum;
                }
                else
                {
                    current = value;
                }
            }
        }

        public IntRangeParameter(string id, string caption, int min, int max, int current)
            : base(id, caption, current)
        {
            this.Minimum = min;
            this.Maximum = max;
            this.Value = current;
        }

        public static implicit operator int(IntRangeParameter p)
        {
            return p.Value;
        }

        public override Parameter Clone()
        {
            return new IntRangeParameter(this.Id, this.Caption, this.Minimum, this.Maximum, this.current);
        }
    }
}
