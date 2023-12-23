using System;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Enemy;

namespace Asteroids.Core.Spawners
{
    public class AsteroidSpawner : Spawner
    {
        private AsteroidData bigAsteroidData;
        private AsteroidData miniAsteroidData;
        private float timeCooldawn;

        public AsteroidSpawner(AsteroidData bigAsteroidData, AsteroidData miniAsteroidData)
        {
            this.bigAsteroidData = bigAsteroidData;
            this.miniAsteroidData = miniAsteroidData;
        }

        public override void Tick(float deltaTime)
        {
            timeCooldawn += deltaTime;
        }

        public override bool CanSpawn()
        {
            return timeCooldawn >= bigAsteroidData.TimeCooldawnSpawn;
        }

        public override AbstractEntity Spawn(Vector position, float rotation)
        {
            Random rnd = new Random();
            Vector direction;
            direction.x = (float)rnd.NextDouble() - 0.5f;
            direction.y = (float)rnd.NextDouble() - 0.5f;
            direction = direction.normalize;
            float speed = (float)rnd.NextDouble() * (bigAsteroidData.MaxSpeed - bigAsteroidData.MinSpeed) + bigAsteroidData.MinSpeed;
            float rotationSpeed = ((float)rnd.NextDouble() - 0.5f) * bigAsteroidData.MaxRotation;

            Asteroid asteroid = new Asteroid(position, rotation, bigAsteroidData.Size, direction, speed, rotationSpeed, bigAsteroidData.ScoreOnDead);
            asteroid.AddComponent<AsteroidDestroy>(new AsteroidDestroy(miniAsteroidData, bigAsteroidData.CountMiniAsteroids));
            timeCooldawn = 0;
            return asteroid;
        }
    }
}
