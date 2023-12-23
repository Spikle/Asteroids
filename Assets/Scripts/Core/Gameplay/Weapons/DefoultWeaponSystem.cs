using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class DefoultWeaponSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<DefoultWeapon>();
            for (int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var weapon = all[i].GetComponent<DefoultWeapon>();

                if (weapon.Attack)
                {
                    all[i].AddComponent<ShootBullet>(new ShootBullet(transform.Position, transform.Rotation, weapon.Config.BulletSize, weapon.Config.BulletSpeed));
                }
            }
        }
    }
}


