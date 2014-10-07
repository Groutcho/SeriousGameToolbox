using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions.Journal
{
    public class SessionJournal
    {
        private List<JournalEvent> entries;
        public ICollection<JournalEvent> Entries { get { return entries; } }

        public SessionJournal()
        {
            entries = new List<JournalEvent>(10);
        }

        public virtual void AddEntry(JournalEvent entry)
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
