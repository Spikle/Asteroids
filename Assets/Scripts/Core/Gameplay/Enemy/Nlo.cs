using System;
using Asteroids.Core.Collision;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class Nlo : AbstractEnemy
    {
        private float speedMove;
        private Transform target;

        public Nlo(Vector position, float rotation, float size, float speedMove, int scoreOnDead) : base(position, rotation, size, scoreOnDead)
        {
            this.size = size;
            this.speedMove = speedMove;
            this.scoreOnDead = scoreOnDead;
        }

        public Nlo(Vector position, float rotation, float size, float speedMove, Transform target, int scoreOnDead) : base(position, rotation, size, scoreOnDead)
        {
            this.size = size;
            this.speedMove = speedMove;
            this.target = target;
            this.scoreOnDead = scoreOnDead;
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public override void Tick(float deltaTime)
        {
            Move(deltaTime);
        }

        protected virtual void Move(float deltaTime)
        {
            if (target == null)
                return;

            Vector direction = (target.Position - Position).normalize;
            Vector delta = direction * speedMove * deltaTime;
            var nextPosition = Position + delta;
            Position = nextPosition;
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


