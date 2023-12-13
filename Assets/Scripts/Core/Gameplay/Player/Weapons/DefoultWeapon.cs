using System;

namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class DefoultWeapon : AbstractWeapon
    {
        public DefoultWeapon(Transform owner, Action<Vector, Vector> shoot) : base(owner, shoot)
        {

        }

        public override bool CanShoot()
        {
            return true;
        }
    }
}
