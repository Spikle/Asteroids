using System;

namespace Asteroids.Core
{
    public abstract class Transform
    {
        public Vector Position { get; set; }
        public float Rotation { get; set; }
        public Vector Forward => Vector.Forward.Rotate(Rotation);

        public Transform (Vector position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

        public void Rotate(float angle)
        {
            if (angle == 0)
                return;

            float newAngle = NormalizeAngle(Rotation + angle);
            Rotation = newAngle;
        }

        private float NormalizeAngle(float angle)
        {
            angle %= 360;

            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }
    }
}
