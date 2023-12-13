using System;

namespace Asteroids.Core
{
    public class WorldRect
    {
        private float wight;
        private float height;
        private Vector center;

        public float Wight => wight;
        public float Height => height;
        public Vector Center => center;

        public WorldRect(float wight, float height, Vector center)
        {
            this.wight = wight;
            this.height = height;
            this.center = center;
        }

        public Vector GetRandomPosition()
        {
            Random rnd = new Random();
            Vector position;
            position.x = rnd.Next((int)(center.x - wight / 2), (int)(center.x + wight / 2));
            position.y = rnd.Next((int)(center.y - height / 2), (int)(center.y + height / 2));
            return position;
        }

        public Vector GetRandomPositionBehindWorld(float offset)
        {
            Vector position = GetRandomPosition();
            Random rnd = new Random();

            if (rnd.NextDouble() >= 0.5)
            {
                if (position.x >= center.x)
                {
                    position.x = wight / 2 + offset;
                }
                else
                {
                    position.x = -wight / 2 - offset;
                }
            }
            else
            {
                if (position.y >= center.y)
                {
                    position.y = height / 2 + offset;
                }
                else
                {
                    position.y = -height / 2 - offset;
                }
            }

            return position;
        }

        public Vector CalculatePointInWorld(Vector position, float offset)
        {
            if (position.x > center.x + wight / 2 + offset)
            {
                position.x = position.x - wight - (offset * 2f);
            }
            else if (position.x < center.x - wight / 2 - offset)
            {
                position.x = position.x + wight + (offset * 2f);
            }

            if (position.y > center.y + height / 2 + offset)
            {
                position.y = position.y - height - (offset * 2f);
            }
            else if (position.y < center.y - height / 2 - offset)
            {
                position.y = position.y + height + (offset * 2f);
            }

            return position;
        }

        public bool PointOutsideWorld(Vector position, float offset)
        {
            if (position.x > center.x + wight / 2 + offset)
            {
                return true;
            }
            else if (position.x < center.x - wight / 2 - offset)
            {
                return true;
            }

            if (position.y > center.y + height / 2 + offset)
            {
                return true;
            }
            else if (position.y < center.y - height / 2 - offset)
            {
                return true;
            }

            return false;
        }
    }
}
