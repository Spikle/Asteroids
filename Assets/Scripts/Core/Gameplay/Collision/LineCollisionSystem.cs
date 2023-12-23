using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Collision
{
    public class LineCollisionSystem : AbstractSystem
    {
        public LineCollisionSystem()
        {

        }

        public override void Tick(float deltaTime)
        {
            AllEntities allLine = GetAllEntities().With<LineCollider>();
            AllEntities allColliders = GetAllEntities().With<Transform>().With<SphereCollider>();

            for (int i = 0; i < allColliders.Count; i++)
            {
                Transform transform = allColliders[i].GetComponent<Transform>();
                SphereCollider collider = allColliders[i].GetComponent<SphereCollider>();

                for (int j = 0; j < allLine.Count; j++)
                {
                    LineCollider line = allLine[j].GetComponent<LineCollider>();

                    if(IsLineCollisionOnCircle(line.Parent.Position, line.Direction, transform.Position, collider.Size))
                    {
                        allColliders[i].AddComponent<Hit>(new Hit(allLine[j]));
                    }
                }
            }
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
    }
}


