namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class LaserConfig
    {
        private int maxBullets;
        private float shootTime;
        private float cooldawnTime;
        private float laserLength;

        public int MaxBullets => maxBullets;
        public float ShootTime => shootTime;
        public float CooldawnTime => cooldawnTime;
        public float LaserLength => laserLength;

        public LaserConfig(int maxBullets, float shootTime, float cooldawnTime, float laserLength)
        {
            this.maxBullets = maxBullets;
            this.shootTime = shootTime;
            this.cooldawnTime = cooldawnTime;
            this.laserLength = laserLength;
        }
    }
}
