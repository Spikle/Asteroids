namespace Asteroids.Core.Gameplay.Enemy
{
    public class AsteroidMovement
    {
        private float size;
        private float minSpeed;
        private float maxSpeed;
        private float maxRotation;
        private float timeCooldawnSpawn;
        private int scoreOnDead;

        public float Size => size;
        public float MinSpeed => minSpeed;
        public float MaxSpeed => maxSpeed;
        public float MaxRotation => maxRotation;
        public float TimeCooldawnSpawn => timeCooldawnSpawn;
        public int ScoreOnDead => scoreOnDead;

        public AsteroidMovement(float size, float minSpeed, float maxSpeed, float maxRotation, float timeCooldawnSpawn, int scoreOnDead)
        {
            this.size = size;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.maxRotation = maxRotation;
            this.timeCooldawnSpawn = timeCooldawnSpawn;
            this.scoreOnDead = scoreOnDead;
        }
    }
}
