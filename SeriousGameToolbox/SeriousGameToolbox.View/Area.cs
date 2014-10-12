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

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            var other = obj as Area;

            if (other != null)
            {
                return other.X == X && other.Y == Y && other.Width == Width && other.Height == Height;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Width.GetHashCode() + Height.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Area : {0}, {1}, {2}, {3}", X, Y, Width, Height);
        }
    }
}
