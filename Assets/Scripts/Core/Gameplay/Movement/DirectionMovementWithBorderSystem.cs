using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Movement
{
    public class DirectionMovementWithBorderSystem : AbstractSystem
    {
        private event Func<Vector, float, Vector> calculateBorderWorld;

        public DirectionMovementWithBorderSystem(Func<Vector, float, Vector> calculateBorderWorld)
        {
            this.calculateBorderWorld = calculateBorderWorld;
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<DirectionMovementWithBorder>();
            for (int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var movement = all[i].GetComponent<DirectionMovementWithBorder>();

                Vector delta = movement.Direction * movement.SpeedMove * deltaTime;
                var nextPosition = transform.Position + delta;
                transform.Position = calculateBorderWorld.Invoke(nextPosition, transform.Size);

                float angleRotate = movement.SpeedRotation * deltaTime;
                transform.Rotation = Utility.NormalizeAngle(transform.Rotation + angleRotate);
            }
        }
    }
}

