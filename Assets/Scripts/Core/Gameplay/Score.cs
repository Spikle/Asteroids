using System;

namespace Asteroids.Core.Gameplay
{
    public class Score
    {
        public event Action<int> OnChanged;
        private int value;

        public int Value => value;

        public void Increase(int value)
        {
            this.value += value;
            OnChanged?.Invoke(this.value);
        }

        public void Reset()
        {
            value = 0;
            OnChanged?.Invoke(this.value);
        }
    }
}
