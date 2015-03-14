using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Users
{
    public class User
    {
        private Guid id;
        public Guid Id { get { return id; } }

        private string description = string.Empty;
        public string Description
        {
            get { return description; }
            set
            {
                if (value == null)
                {
                    description = string.Empty;
                }
                else
                {
                    description = value.Trim();
                }
            }
        }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                Guards.Guard.AgainstNullArgument("name", value);
                name = value.Trim();
            }
        }

        public User()
        {
            this.id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is User))
            {
                return false;
            }

            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            if (other == this)
            {
                return true;
            }

            return (other.id == id && other.name == name);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
