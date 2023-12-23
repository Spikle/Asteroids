namespace Asteroids.Core.Gameplay.Weapon
{
    public class DefoultWeapon
    {
        public DefoultWeaponConfig Config { get; private set; }
        public bool Attack { get; set; }

        public DefoultWeapon(DefoultWeaponConfig config)
        {
            Config = config;
            Attack = false;
        }
    }
}
