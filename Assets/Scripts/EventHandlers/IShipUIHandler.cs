using Asteroids.Core.Gameplay.Player.Weapon;
using EventBusSystem;
using UnityEngine;

namespace Scripts
{
    public interface IShipUIHandler : IGlobalSubscriber
    {
        public void UpdatePosition(Vector2 position);
        public void UpdateAngle(float angle);
        public void UpdateVelocity(float velocity);
        public void UpdateShip(Vector2 position, float angle, float velocity);
        public void UpdateLaser(WeaponInfo weaponInfo);
    }
}

