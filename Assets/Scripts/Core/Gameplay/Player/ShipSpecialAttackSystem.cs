using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Weapon;

namespace Asteroids.Core.Gameplay.Player
{
    public class ShipSpecialAttackSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Input>().With<LaserWeapon>();
            for (int i = 0; i < all.Count; i++)
            {
                var input = all[i].GetComponent<Input>();
                var laserWeapon = all[i].GetComponent<LaserWeapon>();
                laserWeapon.Attack = input.SpecialAttack;
            }
        }
    }
}
