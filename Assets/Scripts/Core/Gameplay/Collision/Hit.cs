using Asteroids.Core.ECS;

namespace Asteroids.Core.Collision
{
    public struct Hit
    {
        public AbstractEntity CollisionEntity { get; private set; }

        public Hit(AbstractEntity collisionEntity)
        {
            CollisionEntity = collisionEntity;
        }
    }
}

