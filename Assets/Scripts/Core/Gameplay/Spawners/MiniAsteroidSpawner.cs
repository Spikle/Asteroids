using System;
using Asteroids.Core.Gameplay.Enemy;

namespace Asteroids.Core.Spawners
{
    public class MiniAsteroidSpawner : Spawner
    {
        private AsteroidMovement asteroidMovement;
        private Func<Vector, float, Vector> calculatePointInWorld;

        public MiniAsteroidSpawner(AsteroidMovement asteroidMovement, Func<Vector, float, Vector> calculatePointInWorld)
        {
            this.asteroidMovement = asteroidMovement;
            this.calculatePointInWorld = calculatePointInWorld;
        }

        public override void Tick(float deltaTime)
        {

        }

        public override bool CanSpawn()
        {
            return true;
        }

        public override Transform Spawn(Vector position, float rotation)
        {
            Random rnd = new Random();
            Vector direction;
            direction.x = (float)rnd.NextDouble() - 0.5f;
            direction.y = (float)rnd.NextDouble() - 0.5f;
            direction = direction.normalize;
            float speed = (float)rnd.NextDouble() * (asteroidMovement.MaxSpeed - asteroidMovement.MinSpeed) + asteroidMovement.MinSpeed;
            float rotationSpeed = ((float)rnd.NextDouble() - 0.5f) * asteroidMovement.MaxRotation;

            MiniAsteroid asteroid = new MiniAsteroid(position, rotation, asteroidMovement.Size, direction, speed, rotationSpeed, asteroidMovement.ScoreOnDead, calculatePointInWorld);
            return asteroid;
        }
    }
}

