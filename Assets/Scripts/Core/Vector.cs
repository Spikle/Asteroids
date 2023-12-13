using System;

namespace Asteroids.Core
{
    [System.Serializable]
    public struct Vector
    {
        public static Vector Zero => new Vector(0, 0);
        public static Vector Forward => new Vector(1, 0);

        public float x;
        public float y;

        public float distance => (float)Math.Sqrt(sqrtDistance);
        public float sqrtDistance => (float)(Math.Pow(x, 2) + Math.Pow(y, 2));
        public Vector normalize => new Vector(x / distance, y / distance);

        public Vector (float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Vector))
            {
                return false;
            }

            return (x == ((Vector)obj).x) && (y == ((Vector)obj).y);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }

        public Vector Rotate(float degrees)
        {
            if (degrees == 0)
                return new Vector(x, y);

            double radians = degrees * Math.PI / 180f;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
            float newX = (float)(x * cos - y * sin);
            float newY = (float)(x * sin + y * cos);
            return new Vector(newX, newY);
        }

        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y);
        public static Vector operator *(Vector a, float factor) => new Vector(a.x * factor, a.y * factor);

        public static float AngleBetween(Vector a, Vector b)
        {
            double sin = a.x * b.y - b.x * a.y;
            double cos = a.x * b.x + a.y * b.y;
            return (float)(Math.Atan2(sin, cos) * (180 / Math.PI));
        }
    }
}
