using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SeriousGameToolbox.I2D.Decorators
{
    public class SolidBackgroundDecorator : Decorator
    {
        protected Color color;

        protected Texture2D texture;
        protected static Dictionary<Color, Texture2D> cache;

        public Color Color
        {
            get { return color; }
            set
            {
                if (color != value)
                {
                    color = value;
                    ReloadTexture(color);
                }
            }
        }

        private void ReloadTexture(UnityEngine.Color color)
        {
            if (cache.ContainsKey(color))
            {
                texture = cache[color];
            }
            else
            {
                texture = new Texture2D(1, 1);
                texture.SetPixel(1, 1, color);
                texture.Apply(false, true);
                cache[color] = texture;
            }
        }

        static SolidBackgroundDecorator()
        {
            cache = new Dictionary<Color, Texture2D>(10);
        }

        public SolidBackgroundDecorator(Rect area, Color color) : base(area)
        {
            this.color = color;

            ReloadTexture(color);
        }

        public override void Draw()
        {
            base.Draw();

            GUI.DrawTexture(area, texture);
        }
    }
}
