using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Weapon;

namespace Asteroids.Core.Gameplay.Player
{
    public class ShipDefoultAttackSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Input>().With<DefoultWeapon>();
            for (int i = 0; i < all.Count; i++)
            {
                var input = all[i].GetComponent<Input>();
                var defoultWeapon = all[i].GetComponent<DefoultWeapon>();
                defoultWeapon.Attack = input.DefoultAttack;
            }
        }
    }
}

