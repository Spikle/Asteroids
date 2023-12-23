using Asteroids.Core.Collision;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Movement;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class Bullet : AbstractEntity
    {
        public Bullet(Vector position, float rotation, float size, float speed) : base()
        {
            Vector direction = Vector.Forward.Rotate(rotation);
            AddComponent<Transform>(new Transform(position, rotation, size));
            AddComponent<DirectionMovementWithoutBorder>(new DirectionMovementWithoutBorder(speed, 0, direction));
            AddComponent<SphereCollider>(new SphereCollider(size));
        }
    }
}
