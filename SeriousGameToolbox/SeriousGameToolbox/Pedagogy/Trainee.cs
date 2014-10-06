using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy
{
    public class Trainee
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

        private static readonly Trainee def = new Trainee()
        {
            name = "Default trainee"
        };
        public static Trainee Default
        {
            get { return def;}
        }
    }
}
