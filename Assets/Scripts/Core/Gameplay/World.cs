using System;
using Asteroids.Core.Collision;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Player.Weapon;
using Asteroids.Core.Spawners;

namespace Asteroids.Core.Gameplay
{
    public class World
    {
        public event Action<int> OnScoreChanged;
        public event Action<Score> OnEndGame;
        public event Action<Vector, Vector> OnDrawLine;

        private TickSystem tickSystem;
        private CollisionSystem collisionSystem;
        private SpawnerSystem spawnerSystem;
        private WorldRect worldRect;
        private Score score;
        private Ship ship;

        private ShipMovement shipMovement;
        private LaserConfig laserConfig;

        private bool isActive;

        public TickSystem TickSystem => tickSystem;

        public World(WorldRect worldRect, ShipMovement shipMovement, AsteroidMovement bigAsteroidMovement, AsteroidMovement miniAsteroidMovement, NloMovement nloMovement, BulletMovement bulletMovement, LaserConfig laserConfig)
        {
            tickSystem = new TickSystem();
            tickSystem.OnDestoryObject += Destory;

            collisionSystem = new CollisionSystem();
            spawnerSystem = new SpawnerSystem(
                new AsteroidSpawner(bigAsteroidMovement, worldRect.CalculatePointInWorld),
                new MiniAsteroidSpawner(miniAsteroidMovement, worldRect.CalculatePointInWorld),
                new NloSpawner(nloMovement),
                new BulletSpawner(bulletMovement, worldRect.PointOutsideWorld)
            );

            this.worldRect = worldRect;
            score = new Score();
            score.OnChanged += ScoreChanged;

            this.shipMovement = shipMovement;
            this.laserConfig = laserConfig;
        }

        public void StartGame(Vector startPosition, int countAsteroids)
        {
            tickSystem.Clear();
            collisionSystem.Clear();
            SpawnShip(startPosition);
            score.Reset();
            for (int i = 0; i < countAsteroids; i++)
            {
                SpawnAsteroid();
            }

            isActive = true;
        }

        private void ScoreChanged(int value)
        {
            OnScoreChanged?.Invoke(value);
        }

        private void EndGame()
        {
            isActive = false;
            OnEndGame?.Invoke(score);
        }

        private void SpawnShip(Vector startPosition)
        {
            ship = new Ship(startPosition, 90, shipMovement, worldRect.CalculatePointInWorld);
            ship.AddMainWeapon(new DefoultWeapon(ship, ShootBullet));
            ship.AddAdditiveWeapon(new LaserWeapon(ship, laserConfig, ShootLazer, () => { OnDrawLine?.Invoke(Vector.Zero, Vector.Zero); }, () => { OnDrawLine?.Invoke(Vector.Zero, Vector.Zero); }));
            ship.OnDestroy += ShipDestory;
            tickSystem.Add(ship);
            collisionSystem.Add(ship);
        }

        public void Tick(float deltaTime)
        {
            if (!isActive)
                return;

            tickSystem.Tick(deltaTime);
            collisionSystem.Tick();
            spawnerSystem.Tick(deltaTime);

            if(spawnerSystem.CanSpawn<AsteroidSpawner>())
            {
                SpawnAsteroid();
            }

            if (spawnerSystem.CanSpawn<NloSpawner>())
            {
                SpawnNlo();
            }
        }

        private void SpawnAsteroid()
        {
            var spawner = spawnerSystem.GetSpawner<AsteroidSpawner>();
            Vector position = worldRect.GetRandomPositionBehindWorld(spawner.AsteroidSize);
            Asteroid asteroid = (Asteroid)spawner.Spawn(position, 0);
            asteroid.OnDestroy += EnemyDestory;
            tickSystem.Add(asteroid);
            collisionSystem.Add(asteroid);
        }

        private void SpawnMiniAsteroid(Vector position)
        {
            MiniAsteroid asteroid = spawnerSystem.Spawn<MiniAsteroidSpawner, MiniAsteroid>(position, 0);
            asteroid.OnDestroy += EnemyDestory;
            tickSystem.Add(asteroid);
            collisionSystem.Add(asteroid);
        }

        private void SpawnNlo()
        {
            var spawner = spawnerSystem.GetSpawner<NloSpawner>();
            Vector position = worldRect.GetRandomPositionBehindWorld(spawner.NloSize);
            Nlo nlo = spawner.Spawn(position, 0, ship);
            nlo.OnDestroy += EnemyDestory;
            tickSystem.Add(nlo);
            collisionSystem.Add(nlo);
        }

        private void ShootBullet(Vector start, Vector direction)
        {
            float rotation = Vector.AngleBetween(Vector.Forward, direction);
            Bullet bullet = spawnerSystem.Spawn<BulletSpawner, Bullet>(start, rotation);
            tickSystem.Add(bullet);
            collisionSystem.Add(bullet);
        }

        private void ShootLazer(Vector start, Vector direction)
        {
            var collisions = collisionSystem.CheckLineCollision(start, direction);
            for(int i = 0; i < collisions.Count; i++)
            {
                collisions[i].OnLineHit(ship);
            }
            OnDrawLine?.Invoke(start, direction);
        }

        private void EnemyDestory(ITickable tickable)
        {
            if(tickable is Asteroid asteroid)
            {
                for (int i = 0; i < 4; i++)
                {
                    SpawnMiniAsteroid(asteroid.Position);
                }
            }

            if (tickable is AbstractEnemy enemy)
            {
                score.Increase(enemy.ScoreOnDead);
            }
        }

        private void ShipDestory(ITickable tickable)
        {
            if (tickable is Ship)
            {
                EndGame();
            }
        }

        private void Destory(ITickable tickable)
        {
            if (tickable is ICollider collider)
            {
                collisionSystem.Remove(collider);
            }
        }
    }
}
