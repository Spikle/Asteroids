namespace Asteroids.Core.Gameplay.Weapon
{
    public class LaserWeapon
    {
        public LaserWeaponConfig Config { get; private set; }
        public bool Attack { get; set; }
        public int Bullets { get; set; }
        public float CooldawnTime { get; set; }

        public LaserWeapon(LaserWeaponConfig config)
        {
            Config = config;
            Attack = false;
            Bullets = 0;
            CooldawnTime = 0;
        }
    }
}

