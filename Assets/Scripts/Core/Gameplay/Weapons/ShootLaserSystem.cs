using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class ShootLaserSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<ShootLaser>();
            for (int i = 0; i < all.Count; i++)
            {
                ShootLaser shootLaser = all[i].GetComponent<ShootLaser>();
                SpawnEntity(new Laser(shootLaser.Parent, shootLaser.ShootTime, shootLaser.LaserLength));
                all[i].RemoveComponent<ShootLaser>();
            }
        }
    }
}

