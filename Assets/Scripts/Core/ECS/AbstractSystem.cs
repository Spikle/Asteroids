using System;

namespace Asteroids.Core.ECS
{
    public abstract class AbstractSystem
    {
        private event Func<AllEntities> GetAllEntitiesEvent;
        private event Action<AbstractEntity> SpawnEntityEvent;
        private event Action<AbstractEntity> DestroyEntityEvent;

        internal void Init(Func<AllEntities> getAllEntities, Action<AbstractEntity> spawnEntityEvent, Action<AbstractEntity> destroyEntityEvent)
        {
            GetAllEntitiesEvent = getAllEntities;
            SpawnEntityEvent = spawnEntityEvent;
            DestroyEntityEvent = destroyEntityEvent;
        }

        public virtual void Init()
        {

        }

        public abstract void Tick(float deltaTime);

        protected AbstractEntity SpawnEntity(AbstractEntity entity)
        {
            SpawnEntityEvent?.Invoke(entity);
            return entity;
        }

        protected T SpawnEntity<T>(T entity) where T : AbstractEntity
        {
            SpawnEntityEvent?.Invoke(entity);
            return entity;
        }

        protected void DestroyEntity(AbstractEntity entity)
        {
            DestroyEntityEvent?.Invoke(entity);
        }

        protected AllEntities GetAllEntities()
        {
            return GetAllEntitiesEvent?.Invoke();
        }
    }
}
