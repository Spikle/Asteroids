using System;
using Asteroids.Core.Collision;

namespace Asteroids.Core.Gameplay.Enemy
{
    public abstract class AbstractEnemy : Transform, ITickable, ICollider
    {
        public event Action<ITickable> OnDestroy;

        protected float size;
        protected int scoreOnDead;

        public float Size => size;
        public Vector Center => Position;
        public int ScoreOnDead => scoreOnDead;

        public AbstractEnemy(Vector position, float rotation, float size, int scoreOnDead) : base(position, rotation)
        {
            this.size = size;
            this.scoreOnDead = scoreOnDead;
        }

        public virtual void Tick(float deltaTime)
        {

        }

        public virtual void OnColliderHit(ICollider other)
        {

        }

        public virtual void OnLineHit(ICollider owner)
        {

        }

        protected virtual void OnDestroyEvent()
        {
            OnDestroy?.Invoke(this);
        }
    }
}
