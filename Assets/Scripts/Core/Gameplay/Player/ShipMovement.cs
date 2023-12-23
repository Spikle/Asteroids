namespace Asteroids.Core.Gameplay.Player
{
    [System.Serializable]
    public class ShipMovement
    {
        public float Acceleration { get; set; }
        public ShipConfig Config { get; private set; }

        public ShipMovement(ShipConfig config)
        {
            Acceleration = 0;
            Config = config;
        }
    }
}
