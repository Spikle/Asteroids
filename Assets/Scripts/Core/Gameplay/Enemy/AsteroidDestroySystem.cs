using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class AsteroidDestroySystem : AbstractSystem
    {
        public AsteroidDestroySystem()
        {

        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Destroy>().With<Transform>().With<AsteroidDestroy>();
            for (int i = 0; i < all.Count; i++)
            {
                Transform transform = all[i].GetComponent<Transform>();
                AsteroidDestroy asteroidDestory = all[i].GetComponent<AsteroidDestroy>();

                for(int j = 0; j < asteroidDestory.CountSpawnMiniAsteroids; j++)
                {
                    SpawnMiniAsteroid(transform, asteroidDestory.MiniAsteroidData);
                }
            }
        }

        private void SpawnMiniAsteroid(Transform parent, AsteroidData asteroidData)
        {
            Random rnd = new Random();
            Vector direction;
            direction.x = (float)rnd.NextDouble() - 0.5f;
            direction.y = (float)rnd.NextDouble() - 0.5f;
            direction = direction.normalize;
            float speed = (float)rnd.NextDouble() * (asteroidData.MaxSpeed - asteroidData.MinSpeed) + asteroidData.MinSpeed;
            float rotationSpeed = ((float)rnd.NextDouble() - 0.5f) * asteroidData.MaxRotation;
            float rotation = (float)rnd.NextDouble() * 360f;

            Asteroid asteroid = new Asteroid(parent.Position, rotation, asteroidData.Size, direction, speed, rotationSpeed, asteroidData.ScoreOnDead);
            SpawnEntity(asteroid);
        }
    }
}

