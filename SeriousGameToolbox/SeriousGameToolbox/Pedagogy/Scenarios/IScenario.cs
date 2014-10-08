using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Pedagogy.Scenarios
{
    public interface IScenario : IUpdatable
    {
        string Name { get; }
        string Description { get; }

        void Start();
        void Stop();
        void Pause();
        void Resume();
    }
}
