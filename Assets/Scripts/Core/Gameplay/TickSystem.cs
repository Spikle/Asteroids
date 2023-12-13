using System;
using System.Collections.Generic;

namespace Asteroids.Core.Gameplay
{
    public class TickSystem
    {
        public event Action<ITickable> OnSpawnObject;
        public event Action<ITickable> OnDestoryObject;

        private List<ITickable> tickables;

        public TickSystem()
        {
            tickables = new List<ITickable>();
        }

        public void Add(ITickable tickable)
        {
            if(!tickables.Contains(tickable))
            {
                tickable.OnDestroy += Remove;
                tickables.Add(tickable);
                OnSpawnObject?.Invoke(tickable);
            }
        }

        public void Remove(ITickable tickable)
        {
            if (tickables.Contains(tickable))
            {
                tickables.Remove(tickable);
                OnDestoryObject?.Invoke(tickable);
            }
        }

        public void Clear()
        {
            List<ITickable> tmpTickables = new List<ITickable>();
            tmpTickables.AddRange(tickables);
            for (int i = 0; i < tmpTickables.Count; i++)
            {
                Remove(tmpTickables[i]);
            }
        }

        public void Tick(float deltaTime)
        {
            List<ITickable> tmpTickables = new List<ITickable>();
            tmpTickables.AddRange(tickables);
            for (int i = 0; i < tmpTickables.Count; i++)
            {
                tmpTickables[i].Tick(deltaTime);
            }
        }
    }
}
