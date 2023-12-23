namespace Asteroids.Core.Collision
{
    public struct SphereCollider
    {
        public float Size { get; private set; }

        public SphereCollider(float size)
        {
            Size = size;
        }
    }
}
