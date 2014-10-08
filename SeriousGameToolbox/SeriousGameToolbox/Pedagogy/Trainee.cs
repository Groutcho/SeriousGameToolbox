using System;

namespace SeriousGameToolbox.Pedagogy
{
    public class Trainee : IEquatable<Trainee>
    {
        private Guid id;
        public Guid Id { get { return id; } }

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("name");
                }

                name = value.Trim();
            }
        }

        public Trainee()
        {
            this.id = Guid.NewGuid();
        }

        private static Trainee defaultTrainee = new Trainee() { name = "Default trainee" };
        public static Trainee Default { get { return defaultTrainee; } }

        public override bool Equals(object obj)
        {
            if (!(obj is Trainee))
            {
                return false;
            }

            return Equals(obj as Trainee);
        }

        public bool Equals(Trainee other)
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
