using UnityEngine;
using System.Collections;
using SeriousGameToolbox.Contracts;

namespace SeriousGameToolbox.I3D
{
    public class Injector : MonoBehaviour
    {
        protected IUpdatable updatableObject;
        protected IDrawable drawableObject;

        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
        }

        protected virtual void Update()
        {
            if (updatableObject != null)
            {
                updatableObject.Update(Time.deltaTime);
            }
        }

        protected virtual void OnGUI()
        {
            if (drawableObject != null)
            {
                drawableObject.Draw();
            }
        }
    }
}
