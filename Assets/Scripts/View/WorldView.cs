using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Weapon;
using UnityEngine;

namespace Scripts.View
{
    public class WorldView : MonoBehaviour, IGameHandler
    {
        public event Action<World> OnCreateWorld;
        public event Action<World> OnDestroyWorld;

        [SerializeField] private ShipData shipData;
        [SerializeField] private AsteroidData bigAsteroidData;
        [SerializeField] private AsteroidData miniAsteroidData;
        [SerializeField] private NloData nloData;
        [SerializeField] private BulletData bulletData;
        [SerializeField] private LaserData laserData;
        [SerializeField] private TransformView shipViewPrefab;
        [SerializeField] private TransformView transformViewPrefab;
        [SerializeField] private LaserView laserViewPrefab;
        [SerializeField] private int startCountAsteroids;

        private World world;
        private bool isActive;
        private List<TransformView> transforms = new List<TransformView>();

        private void Awake()
        {
            transformViewPrefab.gameObject.SetActive(false);
            shipViewPrefab.gameObject.SetActive(false);
            laserViewPrefab.gameObject.SetActive(false);
            EventBusSystem.EventBus.Subscribe(this);
        }

        private void Start()
        {
            transforms = new List<TransformView>();

            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            WorldRect worldRect = new WorldRect(width, height, new Vector(cam.transform.position.x, cam.transform.position.y));
            world = new World(worldRect, shipData.Config, bigAsteroidData.Movement, miniAsteroidData.Movement, nloData.Movement, bulletData.Config, laserData.Config);
            world.OnSpawnEntity += SpawnEntity;
            world.OnDestroyEntity += DestroyEntity;
            world.OnEndGame += EndGame;
            OnCreateWorld?.Invoke(world);
        }

        public void StartGame()
        {
            isActive = true;
            world.StartGame(Vector.Zero, startCountAsteroids);
        }

        private void EndGame(Score score)
        {
            isActive = false;
        }

        private void Update()
        {
            if (!isActive)
                return;

            world.Tick(Time.deltaTime);
        }

        private void SpawnEntity(AbstractEntity entity)
        {
            if (entity is Ship ship)
            {
                TransformView view = SpawnShipView();
                view.SetEntity(ship);
            }
            else if (entity is Asteroid asteroid)
            {
                TransformView view = SpawnTransformView();
                view.SetEntity(asteroid);
                view.SetSprite(bigAsteroidData.GetSprite());
            }
            else if (entity is Nlo nlo)
            {
                TransformView view = SpawnTransformView();
                view.SetEntity(nlo);
                view.SetSprite(nloData.GetSprite());
            }
            else if(entity is Bullet bullet)
            {
                TransformView view = SpawnTransformView();
                view.SetEntity(bullet);
                view.SetSprite(bulletData.GetSprite());
            }
            else if(entity is Laser laser)
            {
                LaserView view = SpawnLaserView();
                view.SetEntity(laser);
            }
        }

        private TransformView SpawnShipView()
        {
            TransformView view = Instantiate(shipViewPrefab, Vector3.zero, Quaternion.identity, transform);
            transforms.Add(view);
            view.gameObject.SetActive(true);

            return view;
        }

        private TransformView SpawnTransformView()
        {
            TransformView view = Instantiate(transformViewPrefab, Vector3.zero, Quaternion.identity, transform);
            transforms.Add(view);
            view.gameObject.SetActive(true);

            return view;
        }

        private LaserView SpawnLaserView()
        {
            LaserView view = Instantiate(laserViewPrefab, Vector3.zero, Quaternion.identity, transform);
            transforms.Add(view);
            view.gameObject.SetActive(true);

            return view;
        }

        private void DestroyEntity(AbstractEntity entity)
        {
            for(int i = 0; i < transforms.Count; i++)
            {
                if (transforms[i].Entity == entity)
                {
                    TransformView view = transforms[i];
                    transforms.RemoveAt(i);
                    Destroy(view.gameObject);
                    break;
                }
            }
        }

        private void OnDestroy()
        {
            world.OnSpawnEntity -= SpawnEntity;
            world.OnDestroyEntity -= DestroyEntity;
            OnDestroyWorld?.Invoke(world);
            EventBusSystem.EventBus.Unsubscribe(this);
        }
    }
}
