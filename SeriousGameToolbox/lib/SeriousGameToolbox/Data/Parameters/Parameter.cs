
using System;
using System.Xml.Serialization;
namespace SeriousGameToolbox.Data.Parameters
{
    public abstract class Parameter : IEquatable<Parameter>
    {
        public string Id { get; private set; }
        public string Caption { get; private set; }

        public Parameter(string id, string caption)
        {
            Guards.Guard.AgainstNullArgument("id", id);

            this.Id = id;

            this.Caption = caption;
        }

        public abstract object GetValue();
        public abstract Parameter Clone();

        public abstract bool Equals(Parameter other);
    }
}