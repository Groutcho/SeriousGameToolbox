using SeriousGameToolbox.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I3D
{
    public class I3DController : IUpdatable
    {
        Injector injector;

        public I3DController()
        {
            injector = UnityEngine.Object.FindObjectOfType<Injector>() ?? (new GameObject("3dInjector")).AddComponent<Injector>();
            UnityEngine.Object.DontDestroyOnLoad(injector);
        }

        public void LoadLevel(string level)
        {
            Application.LoadLevel(level);
        }

        public void Update(double dt)
        {

        }
    }
}
