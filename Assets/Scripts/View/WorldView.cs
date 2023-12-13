using System.Collections;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Gameplay;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Player.Weapon;
using UnityEngine;

namespace Scripts.View
{
    public class WorldView : MonoBehaviour, IGameHandler
    {
        [SerializeField] private ShipData shipData;
        [SerializeField] private AsteroidData bigAsteroidData;
        [SerializeField] private AsteroidData miniAsteroidData;
        [SerializeField] private NloData nloData;
        [SerializeField] private BulletData bulletData;
        [SerializeField] private LaserData laserData;
        [SerializeField] private ShipView shipViewPrefab;
        [SerializeField] private TransformView transformViewPrefab;
        [SerializeField] private int startCountAsteroids;
        [SerializeField] private LineRenderer lineRenderer;

        private World world;
        private bool isActive;
        private List<TransformView> transforms = new List<TransformView>();

        private void Awake()
        {
            transformViewPrefab.gameObject.SetActive(false);
            shipViewPrefab.gameObject.SetActive(false);
            lineRenderer.gameObject.SetActive(false);
            EventBusSystem.EventBus.Subscribe(this);
        }

        private void Start()
        {
            transforms = new List<TransformView>();

            Camera cam = Camera.main;
            float height = 2f * cam.orthographicSize;
            float width = height * cam.aspect;

            WorldRect worldRect = new WorldRect(width, height, new Vector(cam.transform.position.x, cam.transform.position.y));
            world = new World(worldRect, shipData.Movement, bigAsteroidData.Movement, miniAsteroidData.Movement, nloData.Movement, bulletData.Movement, laserData.Config);
            world.TickSystem.OnSpawnObject += OnSpawnObject;
            world.TickSystem.OnDestoryObject += OnDestoryObject;
            world.OnDrawLine += DrawLine;
            world.OnScoreChanged += ScoreChanged;
            world.OnEndGame += EndGame;
        }

        public void StartGame()
        {
            isActive = true;
            EventBusSystem.EventBus.RaiseEvent<IStartUIHandler>(h => h.HideStart());
            EventBusSystem.EventBus.RaiseEvent<IEndUIHandler>(h => h.HideEnd());
            EventBusSystem.EventBus.RaiseEvent<IGameplayUIHandler>(h => h.ShowGameplay());
            world.StartGame(Vector.Zero, startCountAsteroids);
        }

        private void ScoreChanged(int value)
        {
            EventBusSystem.EventBus.RaiseEvent<IScoreUIHandler>(h=> h.UpdateScore(value));
        }

        private void EndGame(Score score)
        {
            EventBusSystem.EventBus.RaiseEvent<IGameplayUIHandler>(h => h.HideGameplay());
            EventBusSystem.EventBus.RaiseEvent<IEndUIHandler>(h => h.ShowEnd(score.Value));
            isActive = false;
        }

        private void Update()
        {
            if (!isActive)
                return;

            world.Tick(Time.deltaTime);
        }

        private void OnSpawnObject(ITickable tickable)
        {
            if (tickable is Ship ship)
            {
                ShipView view = SpawnShipView();
                view.SetTransform(ship);
                view.SetActive(true);
            }
            else if (tickable is Asteroid asteroid)
            {
                TransformView view = SpawnTransformView();
                view.SetTransform(asteroid);
                view.SetSprite(bigAsteroidData.GetSprite());
            }
            else if (tickable is MiniAsteroid miniAsteroid)
            {
                TransformView view = SpawnTransformView();
                view.SetTransform(miniAsteroid);
                view.SetSprite(miniAsteroidData.GetSprite());
            }
            else if (tickable is Nlo nlo)
            {
                TransformView view = SpawnTransformView();
                view.SetTransform(nlo);
                view.SetSprite(nloData.GetSprite());
            }
            else if(tickable is Bullet bullet)
            {
                TransformView view = SpawnTransformView();
                view.SetTransform(bullet);
                view.SetSprite(bulletData.GetSprite());
            }
        }

        private ShipView SpawnShipView()
        {
            ShipView view = Instantiate(shipViewPrefab, Vector3.zero, Quaternion.identity, transform);
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

        private void OnDestoryObject(ITickable tickable)
        {
            for(int i = 0; i < transforms.Count; i++)
            {
                if (transforms[i].TransformObject == tickable)
                {
                    TransformView view = transforms[i];
                    transforms.RemoveAt(i);
                    Destroy(view.gameObject);
                    break;
                }
            }
        }

        private void DrawLine(Vector start, Vector direction)
        {
            Vector3[] points = new Vector3[2];
            points[0] = new Vector3(start.x, start.y, 0);
            points[1] = new Vector3(start.x + direction.x, start.y + direction.y, 0);
            lineRenderer.SetPositions(points);
            lineRenderer.gameObject.SetActive(points[1].sqrMagnitude > 0);
        }

        private void OnDestroy()
        {
            world.TickSystem.OnSpawnObject -= OnSpawnObject;
            world.TickSystem.OnDestoryObject -= OnDestoryObject;
            world.OnDrawLine -= DrawLine;
            EventBusSystem.EventBus.Unsubscribe(this);
        }
    }
}
