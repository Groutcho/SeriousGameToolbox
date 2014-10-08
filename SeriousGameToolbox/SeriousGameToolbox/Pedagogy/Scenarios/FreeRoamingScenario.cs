using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Scenarios
{
    public abstract class Scenario : IScenario
    {
        protected double totalElapsedTimeInSeconds = 0;
        public double TotalElapsedTimeInSeconds { get { return totalElapsedTimeInSeconds; } }

        protected string name = string.Empty;
        public string Name
        {
            get { return name; }
        }

        private string description = string.Empty;
        private bool isPlaying;
        public string Description
        {
            get { return description; }
        }

        public void Start()
        {
            Initialize();

            isPlaying = true;
        }

        protected virtual void Initialize()
        {
            totalElapsedTimeInSeconds = 0;
        }

        public void Stop()
        {
            isPlaying = false;
        }

        public void Pause()
        {
            isPlaying = false;
        }

        public void Resume()
        {
            isPlaying = true;
        }

        public void Update(double dt)
        {
            if (isPlaying)
            {
                totalElapsedTimeInSeconds += dt;
            }
        }
    }
}
