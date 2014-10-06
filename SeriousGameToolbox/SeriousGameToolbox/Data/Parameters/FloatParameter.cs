using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class FloatParameter : Parameter
    {
        protected string id;
        protected string caption;
        protected float current;

        public new  virtual float Value
        {
            get { return current; }
            set
            {
                current = value;
            }
        }

        public FloatParameter(string id, string caption, float current)
            : base(id, caption)
        {
            this.id = id;
            this.caption = caption;
            this.current = current;
        }

        public override Parameter Clone()
        {
            return new FloatParameter(this.id, this.caption, this.current);
        }
    }
}
