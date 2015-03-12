using UnityEngine;
using System.Collections;
using SeriousGameToolbox.I2D.Events;

namespace SeriousGameToolbox.I2D.Controls
{
    public class CursorControl : ImageControl
    {
        public class CursorReachedTargetEvent : ControlEvent
        {
            public CursorReachedTargetEvent(Control sender) : base(sender) { }
        }

        Vector2 target;
        Vector2 currentPos;
        float speed;
        bool isMoving = true;
        float f;

        public CursorControl(Area area, Texture image): base(area, image)
        {

        }

        protected override void DrawControl()
        {
            if (isMoving)
            {
                f += Time.deltaTime * speed;
                var v = Vector2.Lerp(currentPos, target, f);

                area.X = v.x;
                area.Y = v.y;

                if (f >= 1)
                {
                    isMoving = false;
                    BubbleEvent(new CursorReachedTargetEvent(this));
                }
            }

            base.DrawControl();
        }

        public void MoveTo(Vector2 target, float speed)
        {
            currentPos = Area.Center;
            this.target = target;
            this.speed = speed;
            float dist = Vector2.Distance(target, Area.Center);
            f = 0;

            isMoving = true;
        }
    }
}