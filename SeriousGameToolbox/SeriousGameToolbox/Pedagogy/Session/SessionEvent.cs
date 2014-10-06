using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public abstract class SessionEvent
    {
        protected Guid id;
        protected DateTime date;

        public Guid Id { get { return id; } }
        public DateTime Date { get { return date; } }

        public SessionEvent()
        {
            id = Guid.NewGuid();
            date = DateTime.Now;
        }
    }
}
