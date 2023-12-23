namespace Asteroids.Core
{
    public class Transform
    {
        public Vector Position { get; set; }
        public float Rotation { get; set; }
        public float Size { get; set; }
        public Vector Forward => Vector.Forward.Rotate(Rotation);

        public Transform (Vector position, float rotation)
        {
            Position = position;
            Rotation = rotation;
            Size = 1;
        }

        public Transform(Vector position, float rotation, float size)
        {
            Position = position;
            Rotation = rotation;
            Size = size;
        }
    }
}
