namespace Asteroids.Core.Gameplay.Player
{
    [System.Serializable]
    public class ShipMovement
    {
        private float accelerationPerSecond;
        private float slowdownPerSecond;
        private float rotationPerSecond;
        private float maxSpeed;

        public float AccelerationPerSecond => accelerationPerSecond;
        public float SlowdownPerSecond => slowdownPerSecond;
        public float RotationPerSecond => rotationPerSecond;
        public float MaxSpeed => maxSpeed;

        public ShipMovement(float accelerationPerSecond, float slowdownPerSecond, float rotationPerSecond, float maxSpeed)
        {
            this.accelerationPerSecond = accelerationPerSecond;
            this.slowdownPerSecond = slowdownPerSecond;
            this.rotationPerSecond = rotationPerSecond;
            this.maxSpeed = maxSpeed;
        }
    }
}
