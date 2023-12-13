using System;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class MiniAsteroid : AbstractAsteroid
    {
        public MiniAsteroid(Vector position, float rotation, float size, Vector direction, float speedMove, float speedRotate, int scoreOnDead, Func<Vector, float, Vector> calculateBorderWorld) : base(position, rotation, size, direction, speedMove, speedRotate, scoreOnDead, calculateBorderWorld)
        {

        }
    }
}


