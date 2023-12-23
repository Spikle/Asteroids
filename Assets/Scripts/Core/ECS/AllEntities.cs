using System;
using System.Collections.Generic;

namespace Asteroids.Core.ECS
{
    public class AllEntities
    {
        private AbstractEntity[] allEntities;
        private int size;

        public int Count => size;

        public AbstractEntity this[int index]
        {
            get { return allEntities[index]; }
        }

        public AllEntities(List<AbstractEntity> entities)
        {
            size = entities.Count;
            allEntities = entities.ToArray();
        }

        public AllEntities(AbstractEntity[] entities)
        {
            size = entities.Length;
            Array.Copy(entities, allEntities, size);
        }

        public AllEntities With<T>()
        {
            for(int i = size - 1; i >= 0; i--)
            {
                if (!allEntities[i].HasComponent<T>())
                    RemoveAt(i);
            }

            return this;
        }

        private void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
                return;

            Shift(index, -1);
            Array.Clear(allEntities, size, 1);
        }

        private void Shift(int start, int delta)
        {
            if (delta < 0)
                start -= delta;

            if (start < size)
                Array.Copy(allEntities, start, allEntities, start + delta, size - start);

            size += delta;

            if (delta >= 0)
                return;

            Array.Clear(allEntities, size, -delta);
        }
    }
}
