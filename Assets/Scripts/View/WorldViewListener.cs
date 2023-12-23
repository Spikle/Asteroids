using Asteroids.Core.Gameplay;
using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Weapon;
using UnityEngine;
using Transform = Asteroids.Core.Transform;

namespace Scripts.View
{
    [RequireComponent(typeof(WorldView))]
    public class WorldViewListener : MonoBehaviour
    {
        private WorldView worldView;

        private void Awake()
        {
            worldView = GetComponent<WorldView>();
            worldView.OnCreateWorld += CreateWorld;
            worldView.OnDestroyWorld += DestroyWorld;
        }

        private void CreateWorld(World world)
        {
            world.OnStartGame += StartGame;
            world.OnUpdateShip += UpdateShip;
            world.OnScoreChanged += ScoreChanged;
            world.OnUpdateLaser += UpdateLaser;
            world.OnEndGame += EndGame;
        }

        private void DestroyWorld(World world)
        {
            world.OnStartGame -= StartGame;
            world.OnUpdateShip -= UpdateShip;
            world.OnScoreChanged -= ScoreChanged;
            world.OnUpdateLaser -= UpdateLaser;
            world.OnEndGame -= EndGame;
        }

        private void StartGame()
        {
            EventBusSystem.EventBus.RaiseEvent<IStartUIHandler>(h => h.HideStart());
            EventBusSystem.EventBus.RaiseEvent<IEndUIHandler>(h => h.HideEnd());
            EventBusSystem.EventBus.RaiseEvent<IGameplayUIHandler>(h => h.ShowGameplay());
        }

        private void UpdateShip(Ship ship)
        {
            Transform transform = ship.GetComponent<Transform>();
            ShipMovement movement = ship.GetComponent<ShipMovement>();
            EventBusSystem.EventBus.RaiseEvent<IShipUIHandler>(h => h.UpdateShip(new Vector2(transform.Position.x, transform.Position.y), transform.Rotation, movement.Acceleration));
        }

        private void ScoreChanged(int value)
        {
            EventBusSystem.EventBus.RaiseEvent<IScoreUIHandler>(h => h.UpdateScore(value));
        }

        private void UpdateLaser(LaserInfo laserInfo)
        {
            EventBusSystem.EventBus.RaiseEvent<IShipUIHandler>(h => h.UpdateLaser(laserInfo));
        }

        private void EndGame(Score score)
        {
            EventBusSystem.EventBus.RaiseEvent<IGameplayUIHandler>(h => h.HideGameplay());
            EventBusSystem.EventBus.RaiseEvent<IEndUIHandler>(h => h.ShowEnd(score.Value));
        }
    }
}
