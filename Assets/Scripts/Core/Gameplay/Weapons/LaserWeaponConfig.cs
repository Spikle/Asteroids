namespace Asteroids.Core.Gameplay.Weapon
{
    public struct LaserWeaponConfig
    {
        public int MaxBullets { get; private set; }
        public float MaxShootTime { get; private set; }
        public float MaxCooldawnTime { get; private set; }
        public float LaserLength { get; private set; }

        public LaserWeaponConfig(int maxBullets, float shootTime, float cooldawnTime, float laserLength)
        {
            MaxBullets = maxBullets;
            MaxShootTime = shootTime;
            MaxCooldawnTime = cooldawnTime;
            LaserLength = laserLength;
        }
    }
}

