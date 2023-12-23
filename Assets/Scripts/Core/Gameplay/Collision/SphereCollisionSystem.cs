using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Collision
{
    public class SphereCollisionSystem : AbstractSystem
    {
        public SphereCollisionSystem()
        {

        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<SphereCollider>();
            for (int i = 0; i < all.Count; i++)
            {
                Transform firstTransform = all[i].GetComponent<Transform>();
                SphereCollider firstCollider = all[i].GetComponent<SphereCollider>();

                for (int j = 0; j < all.Count; j++)
                {
                    if (i == j)
                        continue;

                    Transform secondTransform = all[j].GetComponent<Transform>();
                    SphereCollider secondCollider = all[j].GetComponent<SphereCollider>();

                    if(IsCollided(firstTransform, firstCollider, secondTransform, secondCollider))
                    {
                        all[i].AddComponent<Hit>(new Hit(all[j]));
                    }
                }
            }
        }

        private bool IsCollided(Transform firstTransform, SphereCollider firstCollider, Transform secondTransform, SphereCollider secondCollider)
        {
            float distance = (secondTransform.Position - firstTransform.Position).sqrtDistance;
            return distance <= Math.Pow(secondCollider.Size / 2f + firstCollider.Size / 2f, 2);
        }
    }
}

