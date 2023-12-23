namespace Asteroids.Core.Gameplay.Enemy
{
    public struct ScoreDestroy
    {
        public int Score { get; private set; }

        public ScoreDestroy(int score)
        {
            Score = score;
        }
    }
}
