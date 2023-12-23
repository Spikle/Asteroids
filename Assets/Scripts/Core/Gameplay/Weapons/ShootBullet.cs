namespace Asteroids.Core.Gameplay.Weapon
{
    public struct ShootBullet
    {
        public Vector StartPosition { get; private set; }
        public float Rotation { get; private set; }
        public float Size { get; private set; }
        public float Speed { get; private set; }

        public ShootBullet(Vector startPosition, float rotation, float size, float speed)
        {
            StartPosition = startPosition;
            Rotation = rotation;
            Size = size;
            Speed = speed;
        }
    }
}
