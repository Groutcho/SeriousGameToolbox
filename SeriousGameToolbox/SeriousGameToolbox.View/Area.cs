using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D
{
    public class Area
    {
        private static Area none = new Area(0, 0, 0, 0);
        public static Area None { get { return none; } }

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Area(float x, float y, float width, float height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public static implicit operator Rect(Area a)
        {
            return new Rect(a.X, a.Y, a.Width, a.Height);
        }
    }
}
