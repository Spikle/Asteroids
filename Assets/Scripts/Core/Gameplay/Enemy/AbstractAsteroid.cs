using System;
using Asteroids.Core.Collision;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Asteroids.Core.Gameplay.Enemy
{
    public abstract class AbstractAsteroid : AbstractEnemy
    {
        private Vector direction;
        private float speedMove;
        private float speedRotate;
        private Func<Vector, float, Vector> calculatePointInWorld;

        public AbstractAsteroid(Vector position, float rotation, float size, Vector direction, float speedMove, float speedRotate, int scoreOnDead, Func<Vector, float, Vector> calculatePointInWorld) : base(position, rotation, size, scoreOnDead)
        {
            this.direction = direction;
            this.speedMove = speedMove;
            this.speedRotate = speedRotate;
            this.calculatePointInWorld = calculatePointInWorld;
        }

        public override void Tick(float deltaTime)
        {
            Move(deltaTime);
            Rotate(speedRotate * deltaTime);
        }

        protected virtual void Move(float deltaTime)
        {
            Vector delta = direction * speedMove * deltaTime;
            var nextPosition = Position + delta;
            float offset = size * 2f;
            Position = calculatePointInWorld.Invoke(nextPosition, offset);
        }

        public override void OnColliderHit(ICollider other)
        {
            if (other is Bullet bullet)
            {
                OnDestroyEvent();
                bullet.Destroy();
            }
        }

        public override void OnLineHit(ICollider owner)
        {
            if (owner is Ship ship)
            {
                OnDestroyEvent();
            }
        }
    }
}

