using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Sessions.Journal
{
    public class QuizAnsweredJournalEvent : JournalEvent
    {
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public string Expected { get; protected set; }

        public bool IsCorrectAnswer
        {
            get { return Answer == Expected; }
        }

        public QuizAnsweredJournalEvent(string quizQuestion, string answer, string expected)
        {
            Guards.Guard.AgainstNullArgument("quizQuestion", quizQuestion);
            Guards.Guard.AgainstNullArgument("answer", answer);
            Guards.Guard.AgainstNullArgument("expected", expected);

            this.Question = quizQuestion;
            this.Answer = answer;
            this.Expected = expected;
        }
    }
}
