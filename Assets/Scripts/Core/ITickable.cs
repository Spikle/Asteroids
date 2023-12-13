using System;

namespace Asteroids.Core
{
    public interface ITickable
    {
        public event Action<ITickable> OnDestroy;
        public void Tick(float deltaTime);
    }
}