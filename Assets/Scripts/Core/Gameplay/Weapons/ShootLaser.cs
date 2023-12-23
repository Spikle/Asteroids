namespace Asteroids.Core.Gameplay.Weapon
{
    public struct ShootLaser
    {
        public Transform Parent { get; private set; }
        public float LaserLength { get; private set; }
        public float ShootTime { get; private set; }

        public ShootLaser(Transform parent, float shootTime, float laserLength)
        {
            Parent = parent;
            LaserLength = laserLength;
            ShootTime = shootTime;
        }
    }
}
