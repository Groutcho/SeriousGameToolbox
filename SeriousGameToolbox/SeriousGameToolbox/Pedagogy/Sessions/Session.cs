using System;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public class Session
    {
        private Guid id;

        protected DateTime date = DateTime.Now;
        protected TimeSpan duration = new TimeSpan(0);
        protected DateTime startTime = DateTime.Now;
        protected DateTime endTime = DateTime.Now;
        protected Trainee trainee = Trainee.Default;
        protected Completion completion = Completion.Unknown;
        protected Success success = Success.Unknown;

        public Guid Id { get { return id; } }
        public DateTime Date { get { return date; } }
        public TimeSpan Duration { get { return duration; } }
        public Score Score { get; set; }
        public Trainee Trainee { get { return trainee; } }
        public Completion Completion { get { return completion; } set { completion = value; } }
        public Success Success { get { return success; } set { success = value; } }

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
            id = Guid.NewGuid();
        }

        public Session(Trainee trainee) :
            this()
        {
            if (trainee == null)
            {
                throw new ArgumentNullException("trainee");
            }

            this.trainee = trainee;
        }
    }
}
