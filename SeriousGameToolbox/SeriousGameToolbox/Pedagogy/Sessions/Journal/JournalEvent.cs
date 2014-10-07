using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public abstract class JournalEvent
    {
        protected Guid id;
        protected DateTime date;

        public Guid Id { get { return id; } }
        public DateTime Date { get { return date; } }

        public JournalEvent()
        {
            id = Guid.NewGuid();
            date = DateTime.Now;
        }

        public JournalEvent(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException("date");
            }

            this.date = date;
            id = Guid.NewGuid();
        }
    }
}
