using SeriousGameToolbox.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I3D
{
    public delegate void LevelLoadedEvent(object sender, LevelLoadedEventArgs args);

    public class I3DController : IUpdatable
    {
        protected Camera currentCamera;

        Injector injector;
        protected Injector Injector { get { return injector; } }

        public event LevelLoadedEvent LevelLoaded;

        public I3DController()
        {
            injector = UnityEngine.Object.FindObjectOfType<Injector>() ?? (new GameObject("3dInjector")).AddComponent<Injector>();
            UnityEngine.Object.DontDestroyOnLoad(injector);
        }

        private IEnumerator LoadLevelRoutine(string level)
        {
            yield return null;

            Application.LoadLevel(level);

            yield return null;

            if (LevelLoaded != null)
            {
                LevelLoaded(this, new LevelLoadedEventArgs(level));
            }
        }

        public void LoadLevel(string level)
        {
            injector.StartCoroutine(LoadLevelRoutine(level));
        }

        public bool IsPC
        {
            get
            {
                bool player = Application.platform == RuntimePlatform.WindowsPlayer;
                bool editor = Application.platform == RuntimePlatform.WindowsEditor;

                return player || editor;
            }
        }

        public bool IsMobileDevice
        {
            get
            {
                bool android = Application.platform == RuntimePlatform.Android;
                bool iOs = Application.platform == RuntimePlatform.IPhonePlayer;

                return android || iOs;
            }
        }

        public virtual void Update(double dt)
        {

        }

        public Ray GetMouseRay()
        {
            Vector2 mousePos = Input.mousePosition;

            if (currentCamera == null)
            {
                currentCamera = Camera.main;
            }
            if (currentCamera == null)
            {
                throw new NullReferenceException("There is no camera to project a ray from.");
            }

            return  currentCamera.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y, 10));
        }

        public GameObject GetClickedObject()
        {
            RaycastHit hit;
            Ray r = GetMouseRay();

            if (Physics.Raycast(r, out hit))
            {
                return hit.collider.gameObject;
            }

            return null;
        }

        public GameObject GetClickedObject(string layer)
        {
            LayerMask mask = LayerMask.NameToLayer(layer);
            RaycastHit hit;
            Ray r = GetMouseRay();

            if (Physics.Raycast(r, out hit, mask))
            {
                return hit.collider.gameObject;
            }

            return null;
        }
    }
}
