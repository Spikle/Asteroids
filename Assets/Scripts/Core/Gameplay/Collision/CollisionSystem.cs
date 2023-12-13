using System;
using System.Collections.Generic;

namespace Asteroids.Core.Collision
{
    public class CollisionSystem
    {
        private List<ICollider> colliders;

        public CollisionSystem()
        {
            colliders = new List<ICollider>();
        }

        public void Add(ICollider collider)
        {
            if (!colliders.Contains(collider))
                colliders.Add(collider);
        }

        public void Remove(ICollider collider)
        {
            if (colliders.Contains(collider))
                colliders.Remove(collider);
        }

        public void Clear()
        {
            colliders.Clear();
        }

        public List<ICollider> CheckLineCollision(Vector start, Vector direction)
        {
            List<ICollider> collisions = new List<ICollider>();

            for (int i = 0; i < colliders.Count; i++)
            {
                var collider = colliders[i];
                if(IsLineCollisionOnCircle(start, direction, collider.Center, collider.Size))
                {
                    collisions.Add(collider);
                }
            }

            return collisions;
        }

        private bool IsLineCollisionOnCircle(Vector start, Vector direction, Vector center, float radius)
        {
            double a = Math.Pow(direction.x, 2) + Math.Pow(direction.y, 2);
            double b = 2 * (direction.x * (start.x - center.x) + direction.y * (start.y - center.y));
            double c = Math.Pow(start.x - center.x, 2) + Math.Pow(start.y - center.y, 2) - Math.Pow(radius, 2);

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
            {
                return false;
            }

            double t1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double t2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

            return t1 >= 0 && t1 <= 1 || t2 >= 0 && t2 <= 1;
        }

        public void Tick()
        {
            CheckCollision();
        }

        private void CheckCollision()
        {
            List<ICollider> tmpColliders = new List<ICollider>();
            tmpColliders.AddRange(colliders);
            for (int i = 0; i < tmpColliders.Count; i++)
            {
                var first = tmpColliders[i];
                for (int j = 0; j < tmpColliders.Count; j++)
                {
                    if (i == j)
                        continue;

                    var second = tmpColliders[j];

                    if (IsCollided(first, second))
                    {
                        first.OnColliderHit(second);
                    }
                }
            }
        }

        private bool IsCollided(ICollider first, ICollider second)
        {
            float distance = (second.Center - first.Center).sqrtDistance;
            return distance <= Math.Pow(second.Size + first.Size, 2);
        }
    }
}