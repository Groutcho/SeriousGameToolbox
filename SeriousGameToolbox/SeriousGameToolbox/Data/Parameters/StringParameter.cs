using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class StringParameter : Parameter
    {
        protected string value;

        public override object GetValue()
        {
            return (object)value;
        }

        public StringParameter(string id, string caption, string value)
            : base(id, caption)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.value = value;
        }

        public override Parameter Clone()
        {
            return new StringParameter(this.Id, this.Caption, this.value);
        }
    }
}
