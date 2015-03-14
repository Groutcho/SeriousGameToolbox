using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions.Journal
{
    public class SessionJournal
    {
        private List<JournalEvent> entries;
        public IList<JournalEvent> Entries { get { return entries; } }

        public SessionJournal()
        {
            entries = new List<JournalEvent>(10);
        }

        public virtual void AddEntry(JournalEvent entry)
        {
            Guards.Guard.AgainstNullArgument("entry", entry);

            if (entries.Any(e => e.Id == entry.Id))
            {
                throw new ArgumentException("An entry with the same id is already contained in the journal.");
            }

            entries.Add(entry);
        }
    }
}
