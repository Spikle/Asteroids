namespace Asteroids.Core.Gameplay.Enemy
{
    public struct AsteroidData
    {
        public float Size { get; private set; }
        public float MinSpeed { get; private set; }
        public float MaxSpeed { get; private set; }
        public float MaxRotation { get; private set; }
        public float TimeCooldawnSpawn { get; private set; }
        public int CountMiniAsteroids { get; private set; }
        public int ScoreOnDead { get; private set; }

        public AsteroidData(float size, float minSpeed, float maxSpeed, float maxRotation, float timeCooldawnSpawn, int countMiniAsteroids, int scoreOnDead)
        {
            Size = size;
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            MaxRotation = maxRotation;
            TimeCooldawnSpawn = timeCooldawnSpawn;
            CountMiniAsteroids = countMiniAsteroids;
            ScoreOnDead = scoreOnDead;
        }
    }
}
