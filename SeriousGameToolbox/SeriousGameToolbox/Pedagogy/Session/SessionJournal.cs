using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public class SessionJournal
    {
        private List<SessionEvent> entries;
        public ICollection<SessionEvent> Entries { get { return entries; } }

        public SessionJournal()
        {
            entries = new List<SessionEvent>(10);
        }

        public virtual void AddEntry(SessionEvent entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            if (entries.Any(e => e.Id == entry.Id))
            {
                throw new ArgumentException("An entry with the same id is already contained in the journal.");
            }

            entries.Add(entry);
        }
    }
}
