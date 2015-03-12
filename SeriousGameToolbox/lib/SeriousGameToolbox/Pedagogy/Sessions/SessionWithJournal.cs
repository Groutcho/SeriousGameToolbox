using SeriousGameToolbox.Pedagogy.Sessions.Journal;
using System;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public class SessionWithJournal : Session
    {
        public SessionJournal Journal { get; protected set; }

        public SessionWithJournal(SessionJournal journal, Trainee trainee) : base(trainee)
        {
            if (journal == null)
            {
                throw new ArgumentNullException("journal");
            }

            this.Journal = journal;
        }
    }
}
