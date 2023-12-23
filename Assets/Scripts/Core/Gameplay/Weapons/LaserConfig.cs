namespace Asteroids.Core.Gameplay.Weapon
{
    public class LaserConfig
    {
        public Transform Parent { get; private set; }
        public float LaserLength { get; private set; }
        public float ShootTime { get; set; }

        public LaserConfig(Transform parent, float shootTime, float laserLength)
        {
            Parent = parent;
            LaserLength = laserLength;
            ShootTime = shootTime;
        }
    }
}
