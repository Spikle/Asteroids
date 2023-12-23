namespace Asteroids.Core.Gameplay.Weapon
{
    public struct DefoultWeaponConfig
    {
        public float BulletSize { get; private set; }
        public float BulletSpeed { get; private set; }

        public DefoultWeaponConfig(float bulletSize, float bulletSpeed)
        {
            BulletSize = bulletSize;
            BulletSpeed = bulletSpeed;
        }
    }
}

