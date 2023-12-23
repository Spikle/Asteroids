using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Weapon;

namespace Asteroids.Core.Collision
{
    public class HitCollisionSystem : AbstractSystem
    {
        public HitCollisionSystem()
        {

        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Hit>();
            for (int i = 0; i < all.Count; i++)
            {
                AbstractEntity entity = all[i];
                Hit hit = entity.GetComponent<Hit>();

                if(entity is Asteroid || entity is Nlo)
                {
                    if (hit.CollisionEntity is Ship ship)
                    {
                        ship.AddComponent<Destroy>(new Destroy());
                    }
                    else if (hit.CollisionEntity is Bullet bullet)
                    {
                        entity.AddComponent<Destroy>(new Destroy());
                        bullet.AddComponent<Destroy>(new Destroy());
                    }
                    else if (hit.CollisionEntity is Laser laser)
                    {
                        entity.AddComponent<Destroy>(new Destroy());
                    }
                }

                entity.RemoveComponent<Hit>();
            }
        }
    }
}

