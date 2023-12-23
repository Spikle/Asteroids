using Asteroids.Core.Collision;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class Laser : AbstractEntity
    {
        public Laser(Transform parent, float shootTime, float laserLength) : base()
        {
            AddComponent<LaserConfig>(new LaserConfig(parent, shootTime, laserLength));
            AddComponent<LineCollider>(new LineCollider(parent, laserLength));
        }
    }
}

