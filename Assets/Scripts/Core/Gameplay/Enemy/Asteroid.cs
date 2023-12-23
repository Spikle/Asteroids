using Asteroids.Core.Collision;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Movement;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class Asteroid : AbstractEntity
    {
        public Asteroid(Vector position, float rotation, float size, Vector direction, float speedMove, float speedRotate, int scoreOnDead) : base()
        {
            AddComponent<Transform>(new Transform(position, rotation, size));
            AddComponent<DirectionMovementWithBorder>(new DirectionMovementWithBorder(speedMove, speedRotate, direction));
            AddComponent<SphereCollider>(new SphereCollider(size));
            AddComponent<ScoreDestroy>(new ScoreDestroy(scoreOnDead));
        }
    }
}
