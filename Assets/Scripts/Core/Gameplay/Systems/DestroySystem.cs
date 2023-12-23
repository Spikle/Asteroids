using Asteroids.Core.ECS;

namespace Asteroids.Core
{
    public class DestroySystem : AbstractSystem
    {
        public DestroySystem()
        {

        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Destroy>();
            for (int i = 0; i < all.Count; i++)
            {
                AbstractEntity entity = all[i];
                DestroyEntity(entity);
            }
        }
    }
}

