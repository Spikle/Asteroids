using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class ShootBulletsSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<ShootBullet>();
            for(int i = 0; i < all.Count; i++)
            {
                ShootBullet shootBullet = all[i].GetComponent<ShootBullet>();
                SpawnEntity(new Bullet(shootBullet.StartPosition, shootBullet.Rotation, shootBullet.Size, shootBullet.Speed));
                all[i].RemoveComponent<ShootBullet>();
            }
        }
    }
}
