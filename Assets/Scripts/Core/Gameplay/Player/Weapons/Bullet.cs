using System;
using Asteroids.Core.Collision;

namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class Bullet : Transform, ITickable, ICollider
    {
        public event Action<ITickable> OnDestroy;

        private float size;
        private float speed;
        private Func<Vector, float, bool> pointOutsideWorld;

        public float Size => size;
        public Vector Center => Position;

        public Bullet(float size, float speed, Vector position, float rotation, Func<Vector, float, bool> pointOutsideWorld) : base(position, rotation)
        {
            this.size = size;
            this.speed = speed;
            this.pointOutsideWorld = pointOutsideWorld;
        }

        public void Tick(float deltaTime)
        {
            Vector delta = Forward * speed * deltaTime;
            Position = Position + delta;

            float offset = size;
            bool isOutside = pointOutsideWorld.Invoke(Position, offset);

            if(isOutside)
            {
                OnDestroy?.Invoke(this);
            }
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
        }

        public void OnColliderHit(ICollider other)
        {
            
        }

        public void OnLineHit(ICollider owner)
        {
            
        }
    }
}
