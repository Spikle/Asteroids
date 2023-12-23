namespace Asteroids.Core.Collision
{
    public struct LineCollider
    {
        public Transform Parent { get; private set; }
        public float Length { get; private set; }
        public Vector Direction => Parent.Forward * Length;

        public LineCollider(Transform parent, float length)
        {
            Parent = parent;
            Length = length;
        }
    }
}

