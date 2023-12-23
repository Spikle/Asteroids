using Asteroids.Core.ECS;

namespace Asteroids.Core.Spawners
{
    public abstract class Spawner
    {
        public abstract void Tick(float deltaTime);
        public abstract bool CanSpawn();
        public abstract AbstractEntity Spawn(Vector position, float rotation);
    }
}
