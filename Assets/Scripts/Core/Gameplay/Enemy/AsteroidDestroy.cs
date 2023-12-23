namespace Asteroids.Core.Gameplay.Enemy
{
    public struct AsteroidDestroy
    {
        public AsteroidData MiniAsteroidData { get; private set; }
        public int CountSpawnMiniAsteroids { get; private set; }

        public AsteroidDestroy(AsteroidData miniAsteroidData, int countSpawnMiniAsteroids)
        {
            MiniAsteroidData = miniAsteroidData;
            CountSpawnMiniAsteroids = countSpawnMiniAsteroids;
        }
    }
}
