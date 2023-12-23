using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Movement
{
    public class FollowMovementSystem : AbstractSystem
    {
        public FollowMovementSystem()
        {
            
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<FollowMovement>();
            for (int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var movement = all[i].GetComponent<FollowMovement>();

                Vector direction = (movement.Target.Position - transform.Position).normalize;
                Vector delta = direction * movement.SpeedMove * deltaTime;
                transform.Position += delta;
            }
        }
    }
}


