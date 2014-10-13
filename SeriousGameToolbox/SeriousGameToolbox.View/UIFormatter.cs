using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D
{
    public class UIFormatter
    {
        public static GUIStyle ResolveStyle(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }

            string[] split = path.Split('/');
            
            var skin = Resources.Load(split[0]) as GUISkin;

            if (skin == null)
            {
                throw new NullReferenceException("Impossible to find the skin " + split[0]);
            }

            var style = skin.GetStyle(split[split.Length-1]);

            if (style == null)
            {
                throw new NullReferenceException(String.Format("Impossible to find the style {0} in the skin {1}", split[0], split[1]));
            }

            return style;
        }
    }
}
