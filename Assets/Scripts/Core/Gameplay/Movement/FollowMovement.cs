namespace Asteroids.Core.Gameplay.Movement
{
    public struct FollowMovement
    {
        public float SpeedMove { get; private set; }
        public Transform Target { get; private set; }

        public FollowMovement(float speedMove, Transform target)
        {
            SpeedMove = speedMove;
            Target = target;
        }
    }
}
