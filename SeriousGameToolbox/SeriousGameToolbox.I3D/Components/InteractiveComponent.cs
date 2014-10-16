using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.I3D.Components
{
    public class InteractiveComponent
    {
        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    name = value;
                }
            }
        }
        public bool Interactive { get; set; }

        /// <summary>
        /// When a components contains references in the 3d Scene, 
        /// this method can be called to load them once the scene is available.
        /// </summary>
        public virtual void LoadReferences()
        {

        }

        public override string ToString()
        {
            return string.Format("Interactive Component : {0}", Name);
        }
    }
}
