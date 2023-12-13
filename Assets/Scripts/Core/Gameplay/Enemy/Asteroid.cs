using System;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class Asteroid : AbstractAsteroid
    {
        public Asteroid(Vector position, float rotation, float size, Vector direction, float speedMove, float speedRotate, int scoreOnDead, Func<Vector, float, Vector> calculatePointInWorld) : base(position, rotation, size, direction, speedMove, speedRotate, scoreOnDead, calculatePointInWorld)
        {

        }
    }
}
