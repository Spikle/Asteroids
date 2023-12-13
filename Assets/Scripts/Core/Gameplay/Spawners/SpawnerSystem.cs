using System;

namespace Asteroids.Core.Spawners
{
    public class SpawnerSystem
    {
        private Spawner[] spawners;

        public SpawnerSystem(params Spawner[] spawners)
        {
            this.spawners = spawners;
        }

        public void Tick(float deltaTime)
        {
            for(int i = 0; i < spawners.Length; i++)
            {
                spawners[i].Tick(deltaTime);
            }
        }

        public bool CanSpawn<T>() where T : Spawner
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (spawners[i] is T)
                {
                    return spawners[i].CanSpawn();
                }
            }

            return false;
        }

        public T GetSpawner<T>() where T : Spawner
        {
            for (int i = 0; i < spawners.Length; i++)
            {
                if (spawners[i] is T spawner)
                {
                    return spawner;
                }
            }

            return null;
        }

        public U Spawn<T, U>(Vector position, float rotation) where T : Spawner where U : Transform
        {
            for(int i = 0; i < spawners.Length; i++)
            {
                if (spawners[i] is T)
                {
                    try
                    {
                        return (U)spawners[i].Spawn(position, rotation);
                    }catch(Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return null;
        }
    }
}
