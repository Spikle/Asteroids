namespace Asteroids.Core.Gameplay.Player
{
    [System.Serializable]
    public struct ShipConfig
    {
        public float AccelerationPerSecond { get; private set; }
        public float SlowdownPerSecond { get; private set; }
        public float RotationPerSecond { get; private set; }
        public float MaxSpeed { get; private set; }

        public ShipConfig(float accelerationPerSecond, float slowdownPerSecond, float rotationPerSecond, float maxSpeed)
        {
            AccelerationPerSecond = accelerationPerSecond;
            SlowdownPerSecond = slowdownPerSecond;
            RotationPerSecond = rotationPerSecond;
            MaxSpeed = maxSpeed;
        }
    }
}

