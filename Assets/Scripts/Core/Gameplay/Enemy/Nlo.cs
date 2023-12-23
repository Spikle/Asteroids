using Asteroids.Core.Collision;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Movement;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class Nlo : AbstractEntity
    {
        public Nlo(Vector position, float rotation, float size, float speedMove, int scoreOnDead) : base()
        {
            AddComponent<Transform>(new Transform(position, rotation, size));
            AddComponent<SphereCollider>(new SphereCollider(size));
            AddComponent<ScoreDestroy>(new ScoreDestroy(scoreOnDead));
        }

        public Nlo(Vector position, float rotation, float size, float speedMove, Transform target, int scoreOnDead) : base()
        {
            AddComponent<Transform>(new Transform(position, rotation, size));
            AddComponent<FollowMovement>(new FollowMovement(speedMove, target));
            AddComponent<SphereCollider>(new SphereCollider(size));
            AddComponent<ScoreDestroy>(new ScoreDestroy(scoreOnDead));
        }
    }
}


