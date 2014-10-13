using SeriousGameToolbox.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I3D
{
    public class I3DController : IUpdatable
    {
        public void LoadLevel(string level)
        {
           Application.LoadLevel(level);
        }

        public void Update(double dt)
        {
            
        }
    }
}
