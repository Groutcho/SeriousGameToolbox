using System;

namespace SeriousGameToolbox.Pedagogy
{
    public class Session
    {
        protected DateTime date = DateTime.Now;
        protected TimeSpan duration = new TimeSpan(0);

        public DateTime Date { get { return date; } }
        public TimeSpan Duration { get { return duration; } }

        private DateTime startTime = DateTime.Now;
        private DateTime endTime = DateTime.Now;

        public virtual void Start()
        {
            date = DateTime.Today;
            startTime = DateTime.Now;
        }

        public virtual void End()
        {
            endTime = DateTime.Now;
            duration = endTime - startTime;
        }

        public Session()
        {

        }
    }
}
