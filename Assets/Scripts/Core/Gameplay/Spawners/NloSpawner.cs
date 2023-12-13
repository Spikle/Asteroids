using Asteroids.Core.Gameplay.Enemy;

namespace Asteroids.Core.Spawners
{
    public class NloSpawner : Spawner
    {
        private NloMovement nloMovement;
        private float timeCooldawn;

        public float NloSize => nloMovement.Size;

        public NloSpawner(NloMovement nloMovement)
        {
            this.nloMovement = nloMovement;
        }

        public override void Tick(float deltaTime)
        {
            timeCooldawn += deltaTime;
        }

        public override bool CanSpawn()
        {
            return timeCooldawn >= nloMovement.TimeCooldawnSpawn;
        }

        public override Transform Spawn(Vector position, float rotation)
        {
            Nlo nlo = new Nlo(position, rotation, nloMovement.Size, nloMovement.Speed, nloMovement.ScoreOnDead);
            timeCooldawn = 0;
            return nlo;
        }

        public Nlo Spawn(Vector position, float rotation, Transform target)
        {
            Nlo nlo = new Nlo(position, rotation, nloMovement.Size, nloMovement.Speed, target, nloMovement.ScoreOnDead);
            timeCooldawn = 0;
            return nlo;
        }
    }
}

