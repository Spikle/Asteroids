using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Player
{
    public class ShipMovementSystem : AbstractSystem
    {
        public event Action<Ship> OnUpdateShip;

        private event Func<Vector, float, Vector> calculateBorderWorld;

        public ShipMovementSystem(Action<Ship> onUpdateShip, Func<Vector, float, Vector> calculateBorderWorld)
        {
            OnUpdateShip = onUpdateShip;
            this.calculateBorderWorld = calculateBorderWorld;
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<Input>().With<ShipMovement>();
            for(int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var input = all[i].GetComponent<Input>();
                var movement = all[i].GetComponent<ShipMovement>();

                bool updated = false;

                float acceleration = movement.Acceleration + (input.Direction * movement.Config.AccelerationPerSecond * deltaTime) - (movement.Config.SlowdownPerSecond * deltaTime);
                acceleration = Math.Clamp(acceleration, 0, movement.Config.MaxSpeed);

                if (acceleration != movement.Acceleration)
                    updated = true;

                movement.Acceleration = acceleration;

                Vector delta = transform.Forward * movement.Acceleration;
                var nextPosition = transform.Position + delta;
                transform.Position = calculateBorderWorld.Invoke(nextPosition, 0);

                float angleRotate = input.Rotation * movement.Config.RotationPerSecond * deltaTime;
                if(angleRotate != 0)
                {
                    transform.Rotation = Utility.NormalizeAngle(transform.Rotation + angleRotate);
                    updated = true;
                }

                if(updated && all[i] is Ship ship)
                {
                    OnUpdateShip?.Invoke(ship);
                }
            }
        }
    }
}
