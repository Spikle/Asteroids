using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Movement
{
    public class DirectionMovementWithoutBorderSystem : AbstractSystem
    {
        private event Func<Vector, float, bool> pointOutsideWorld;

        public DirectionMovementWithoutBorderSystem(Func<Vector, float, bool> pointOutsideWorld)
        {
            this.pointOutsideWorld = pointOutsideWorld;
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<DirectionMovementWithoutBorder>();
            for (int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var movement = all[i].GetComponent<DirectionMovementWithoutBorder>();

                Vector delta = movement.Direction * movement.SpeedMove * deltaTime;
                transform.Position += delta;

                float angleRotate = movement.SpeedRotation * deltaTime;
                transform.Rotation = Utility.NormalizeAngle(transform.Rotation + angleRotate);

                if(pointOutsideWorld.Invoke(transform.Position, transform.Size))
                {
                    all[i].AddComponent<Destroy>(new Destroy());
                }
            }
        }
    }
}
