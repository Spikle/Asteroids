using UnityEngine;
using TMPro;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Scripts.UI
{
    public class GameplayMenu : AbstractMenuUI, IScoreUIHandler, IShipUIHandler
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI positionText;
        [SerializeField] private TextMeshProUGUI angleText;
        [SerializeField] private TextMeshProUGUI velocityText;
        [SerializeField] private TextMeshProUGUI laserText;

        private void Awake()
        {
            EventBusSystem.EventBus.Subscribe(this);
        }

        private void OnDestroy()
        {
            EventBusSystem.EventBus.Unsubscribe(this);
        }

        public override void Open()
        {
            scoreText.text = "0";
            positionText.text = "(0,0)";
            angleText.text = "0";
            velocityText.text = "0";
        }

        public override void UpdateView()
        {

        }

        public override void Close()
        {
            
        }

        public void UpdateScore(int value)
        {
            scoreText.text = value.ToString();
        }

        public void UpdateShip(Vector2 position, float angle, float velocity)
        {
            UpdatePosition(position);
            UpdateAngle(angle);
            UpdateVelocity(velocity);
        }

        public void UpdatePosition(Vector2 position)
        {
            string x = position.x.ToString("0.00");
            string y = position.y.ToString("0.00");
            positionText.text = $"({x},{y})";
        }

        public void UpdateAngle(float angle)
        {
            angleText.text = $"{(int)angle}";
        }

        public void UpdateVelocity(float velocity)
        {
            velocityText.text = velocity.ToString("0.0000");
        }

        public void UpdateLaser(WeaponInfo weaponInfo)
        {
            laserText.text = weaponInfo.GetInfo();
        }
    }
}
