using System;
using Asteroids.Core.Collision;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Movement;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Weapon;
using Asteroids.Core.Spawners;

namespace Asteroids.Core.Gameplay
{
    public class World : AbstractWorld
    {
        public event Action OnStartGame;
        public event Action<int> OnScoreChanged;
        public event Action<Ship> OnUpdateShip;
        public event Action<LaserInfo> OnUpdateLaser;
        public event Action<Score> OnEndGame;

        private SpawnerSystem spawnerSystem;
        private WorldRect worldRect;
        private Score score;

        private ShipConfig shipConfig;
        private DefoultWeaponConfig defoultWeaponConfig;
        private LaserWeaponConfig laserWeaponConfig;

        private AsteroidData bigAsteroidData;

        private Ship ship;

        private bool isActive;

        public World(WorldRect worldRect, ShipConfig shipConfig, AsteroidData bigAsteroidData, AsteroidData miniAsteroidData, NloData nloMovement, DefoultWeaponConfig defoultWeaponConfig, LaserWeaponConfig laserWeaponConfig)
        {
            spawnerSystem = new SpawnerSystem(
                new AsteroidSpawner(bigAsteroidData, miniAsteroidData),
                new NloSpawner(nloMovement)
            );

            this.worldRect = worldRect;
            score = new Score();
            score.OnChanged += ScoreChanged;

            this.bigAsteroidData = bigAsteroidData;

            this.shipConfig = shipConfig;
            this.defoultWeaponConfig = defoultWeaponConfig;
            this.laserWeaponConfig = laserWeaponConfig;

            InitSystems();
        }

        private void InitSystems()
        {
            AddSystem(new ShipMovementSystem(UpdateShip, worldRect.CalculatePointInWorld));
            AddSystem(new ShipDefoultAttackSystem());
            AddSystem(new ShipSpecialAttackSystem());
            AddSystem(new DefoultWeaponSystem());
            AddSystem(new LaserWeaponSystem(UpdateLaser));
            AddSystem(new ShootBulletsSystem());
            AddSystem(new ShootLaserSystem());
            AddSystem(new LaserSystem());
            AddSystem(new DirectionMovementWithBorderSystem(worldRect.CalculatePointInWorld));
            AddSystem(new DirectionMovementWithoutBorderSystem(worldRect.PointOutsideWorld));
            AddSystem(new FollowMovementSystem());
            AddSystem(new SphereCollisionSystem());
            AddSystem(new LineCollisionSystem());
            AddSystem(new HitCollisionSystem());
            AddSystem(new ScoreDestroySystem(score.Increase));
            AddSystem(new AsteroidDestroySystem());
            AddSystem(new DestroySystem());
        }

        public void StartGame(Vector startPosition, int countAsteroids)
        {
            ClearAllEntities();
            SpawnShip(startPosition);
            score.Reset();
            for (int i = 0; i < countAsteroids; i++)
            {
                SpawnAsteroid();
            }

            isActive = true;
            OnStartGame?.Invoke();
        }

        private void SpawnShip(Vector startPosition)
        {
            ship = new Ship(startPosition, 90, 1f, shipConfig, defoultWeaponConfig, laserWeaponConfig);
            AddEntity(ship);
        }

        public override void Tick(float deltaTime)
        {
            if (!isActive)
                return;

            base.Tick(deltaTime);

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
            Vector position = worldRect.GetRandomPositionBehindWorld(bigAsteroidData.Size);
            Asteroid asteroid = spawnerSystem.Spawn<AsteroidSpawner, Asteroid>(position, 0);
            AddEntity(asteroid);
        }

        private void SpawnNlo()
        {
            var spawner = spawnerSystem.GetSpawner<NloSpawner>();
            Vector position = worldRect.GetRandomPositionBehindWorld(spawner.NloSize);
            Nlo nlo = spawner.Spawn(position, 0, ship.GetComponent<Transform>());
            AddEntity(nlo);
        }

        public override void DestroyEntity(AbstractEntity entity)
        {
            base.DestroyEntity(entity);
            if(isActive && entity is Ship)
            {
                EndGame();
            }
        }

        private void UpdateShip(Ship ship)
        {
            OnUpdateShip?.Invoke(ship);
        }

        private void UpdateLaser(LaserInfo laserInfo)
        {
            OnUpdateLaser?.Invoke(laserInfo);
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
    }
}
