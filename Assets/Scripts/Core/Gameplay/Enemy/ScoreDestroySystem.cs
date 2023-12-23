using System;
using Asteroids.Core.ECS;

namespace Asteroids.Core.Gameplay.Enemy
{
    public class ScoreDestroySystem : AbstractSystem
    {
        public event Action<int> OnAddScore;

        public ScoreDestroySystem(Action<int> onAddScore)
        {
            OnAddScore = onAddScore;
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Destroy>().With<ScoreDestroy>();
            for (int i = 0; i < all.Count; i++)
            {
                ScoreDestroy scoreDestroy = all[i].GetComponent<ScoreDestroy>();
                OnAddScore?.Invoke(scoreDestroy.Score);
            }
        }
    }
}
