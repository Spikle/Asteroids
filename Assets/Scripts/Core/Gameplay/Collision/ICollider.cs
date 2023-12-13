namespace Asteroids.Core.Collision
{
    public interface ICollider
    {
        public float Size { get; }
        public Vector Center { get; }
        public void OnColliderHit(ICollider other);
        public void OnLineHit(ICollider owner);
    }
}
