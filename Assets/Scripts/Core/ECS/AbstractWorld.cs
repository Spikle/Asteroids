using System;
using System.Collections.Generic;

namespace Asteroids.Core.ECS
{
    public abstract class AbstractWorld
    {
        public event Action<AbstractEntity> OnSpawnEntity;
        public event Action<AbstractEntity> OnDestroyEntity;

        private List<AbstractSystem> systems;
        private List<AbstractEntity> entities;

        public AbstractWorld()
        {
            systems = new List<AbstractSystem>();
            entities = new List<AbstractEntity>();
        }

        public virtual void Tick(float deltaTime)
        {
            for(int i = 0; i < systems.Count; i++)
            {
                systems[i].Tick(deltaTime);
            }
        }

        public void AddSystem(AbstractSystem system)
        {
            if (!systems.Contains(system))
            {
                systems.Add(system);
                system.Init(GetAllEntities, AddEntity, RemoveEntity);
                system.Init();
            }
        }

        public void RemoveSystem(AbstractSystem system)
        {
            if (systems.Contains(system))
                systems.Remove(system);
        }

        public void AddEntity(AbstractEntity entity)
        {
            if(!entities.Contains(entity))
            {
                entities.Add(entity);
                SpawnEntity(entity);
            }
        }

        public void RemoveEntity(AbstractEntity entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
                DestroyEntity(entity);
            }
        }

        public void Clear()
        {
            ClearAllEntities();
            systems.Clear();
        }

        public void ClearAllEntities()
        {
            for(int i = entities.Count - 1; i >= 0; i--)
            {
                RemoveEntity(entities[i]);
            }
        }

        protected virtual void SpawnEntity(AbstractEntity entity)
        {
            OnSpawnEntity?.Invoke(entity);
        }

        protected virtual void DestroyEntity(AbstractEntity entity)
        {
            OnDestroyEntity?.Invoke(entity);
        }

        protected AllEntities GetAllEntities()
        {
            return new AllEntities(entities);
        }
    }
}

