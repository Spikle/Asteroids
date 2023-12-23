using System;
using System.Collections.Generic;

namespace Asteroids.Core.ECS
{
    public abstract class AbstractEntity
    {
        public event Action<AbstractEntity> OnDestroy;

        private List<object> components;

        public AbstractEntity()
        {
            components = new List<object>();
        }

        public T GetComponent<T>()
        {
            for(int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                    return (T)components[i];
            }

            return default(T);
        }

        public bool HasComponent<T>()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                    return true;
            }

            return false;
        }

        public void AddComponent<T>(T component)
        {
            if(!components.Contains(component))
                components.Add(component);
        }

        public void RemoveComponent<T>()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                {
                    components.RemoveAt(i);
                    return;
                }
            }
        }

        internal void Destroy()
        {
            OnDestroy?.Invoke(this);
        }
    }
}
