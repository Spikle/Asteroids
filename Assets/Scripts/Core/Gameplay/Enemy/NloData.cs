namespace Asteroids.Core.Gameplay.Enemy
{
    public class NloData
    {
        private float size;
        private float speed;
        private float timeCooldawnSpawn;
        private int scoreOnDead;

        public float Size => size;
        public float Speed => speed;
        public float TimeCooldawnSpawn => timeCooldawnSpawn;
        public int ScoreOnDead => scoreOnDead;

        public NloData(float size, float speed, float timeCooldawnSpawn, int scoreOnDead)
        {
            this.size = size;
            this.speed = speed;
            this.timeCooldawnSpawn = timeCooldawnSpawn;
            this.scoreOnDead = scoreOnDead;
        }
    }
}

