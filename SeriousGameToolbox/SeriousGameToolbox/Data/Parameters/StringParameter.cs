using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class StringParameter : Parameter
    {
        protected string id;
        protected string caption;
        protected string value;

        public new virtual string Value
        {
            get { return value; }
            set
            {
                this.value = value;
            }
        }

        public StringParameter(string id, string caption, string value)
            : base(id, caption)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.id = id;
            this.caption = caption;
            this.value = value;
        }

        public override Parameter Clone()
        {
            return new StringParameter(this.id, this.caption, this.value);
        }
    }
}
