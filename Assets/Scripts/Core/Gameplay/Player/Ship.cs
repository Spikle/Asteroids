using Asteroids.Core.Collision;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Weapon;

namespace Asteroids.Core.Gameplay.Player
{
    public class Ship : AbstractEntity
    {
        public Ship(Vector position, float rotation, float size, ShipConfig config, DefoultWeaponConfig defoultWeaponConfig, LaserWeaponConfig laserWeaponConfig) : base()
        {
            AddComponent<Transform>(new Transform(position, rotation, size));
            AddComponent<Input>(new Input(new InputControls()));
            AddComponent<ShipMovement>(new ShipMovement(config));
            AddComponent<SphereCollider>(new SphereCollider(size));
            AddComponent<DefoultWeapon>(new DefoultWeapon(defoultWeaponConfig));
            AddComponent<LaserWeapon>(new LaserWeapon(laserWeaponConfig));
        }
    }
}
