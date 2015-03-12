using SeriousGameToolbox.Data.Users;
using System;

namespace SeriousGameToolbox.Pedagogy
{
    public class Trainee : User
    {
        public Trainee()
        {
            Description = "Trainee";
        }

        private static Trainee defaultTrainee = new Trainee() { Name = "Default trainee" };
        public static Trainee Default { get { return defaultTrainee; } }
    }
}
