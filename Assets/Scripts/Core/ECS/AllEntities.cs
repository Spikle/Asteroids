using System.Collections.Generic;

namespace Asteroids.Core.ECS
{
    public class AllEntities
    {
        private AbstractEntity[] allEntities;

        public AbstractEntity this[int index]
        {
            get { return allEntities[index]; }
        }

        public int Count => allEntities.Length;

        public AllEntities(List<AbstractEntity> entities)
        {
            allEntities = entities.ToArray();
        }

        public AllEntities(AbstractEntity[] entities)
        {
            allEntities = entities;
        }

        public AllEntities With<T>()
        {
            List<AbstractEntity> entities = new List<AbstractEntity>();

            for(int i = 0; i < allEntities.Length; i++)
            {
                if (allEntities[i].HasComponent<T>())
                    entities.Add(allEntities[i]);
            }

            return new AllEntities(entities);
        }
    }
}
