namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class BulletMovement
    {
        private float size;
        private float speed;

        public float Size => size;
        public float Speed => speed;

        public BulletMovement(float size, float speed)
        {
            this.size = size;
            this.speed = speed;
        }
    }
}

