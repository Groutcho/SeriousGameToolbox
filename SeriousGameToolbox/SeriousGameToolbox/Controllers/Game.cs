using SeriousGameToolbox.Contracts;
using SeriousGameToolbox.Controllers.Phases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Controllers
{
    public class Game : IUpdatable
    {
        public string CurrentPhase
        {
            get
            {
                if (phases != null && phases.Count >= currentPhaseIndex)
                {
                    return phases[currentPhaseIndex].Name;
                }
                else
                {
                    return "None";
                }
            }
        }

        protected double timeSinceStartInSeconds;

        protected List<Phase> phases;
        private int currentPhaseIndex;

        public Game()
        {
            phases = new List<Phase>(3);

            Initialize();

            Start();
        }

        public void Update(double dt)
        {
            timeSinceStartInSeconds += dt;
            phases[currentPhaseIndex].Update(dt);
        }

        protected virtual void Initialize()
        {

        }

        void Start()
        {
            if (phases == null)
            {
                throw new NullReferenceException("the phases list is null.");
            }

            if (phases.Count == 0)
            {
                throw new ApplicationException("There is no phase to execute. Shutting down.");
            }

            timeSinceStartInSeconds = 0;

            currentPhaseIndex = 0;
            
            StartPhase(phases[currentPhaseIndex]);
        }

        protected void Restart()
        {
            Reset();

            timeSinceStartInSeconds = 0;

            currentPhaseIndex = 0;

            StartPhase(phases[currentPhaseIndex]);
        }

        protected virtual void Reset()
        {
            
        }

        private void StartPhase(Phase phase)
        {
            OnInitializePhase(phase);

            phase.Completed += OnPhaseCompleted;
            phase.Start();
        }

        private void StopPhase(Phase phase)
        {
            phase.Stop();
            phase.Completed -= OnPhaseCompleted;
        }

        /// <summary>
        /// This is where derived Game implementations will feed the phase with custom input.
        /// </summary>
        protected virtual void OnInitializePhase(Phase phase)
        {
        }

        /// <summary>
        /// This is where the phase output is processed by the Game.
        /// </summary>
        protected virtual void OnPhaseCompleted(Phase sender, PhaseCompletedEventArgs args)
        {
            StopPhase(phases[currentPhaseIndex]);

            if (currentPhaseIndex < phases.Count)
            {
                currentPhaseIndex++;
                StartPhase(phases[currentPhaseIndex]);
            }          
        }
    }
}
