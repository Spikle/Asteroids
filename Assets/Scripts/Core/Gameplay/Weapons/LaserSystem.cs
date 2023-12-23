using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class LaserSystem : AbstractSystem
    {
        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<LaserConfig>();
            for (int i = 0; i < all.Count; i++)
            {
                LaserConfig config = all[i].GetComponent<LaserConfig>();
                config.ShootTime -= deltaTime;
                if(config.ShootTime <= 0)
                {
                    all[i].AddComponent<Destroy>(new Destroy());
                }
            }
        }
    }
}


