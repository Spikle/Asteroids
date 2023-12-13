using Asteroids.Core.Gameplay.Player;
using UnityEngine;

namespace Scripts.View
{
    [CreateAssetMenu(fileName = "Ship Data", menuName = "Objects/Ship", order = 0)]
    public class ShipData : ScriptableObject
    {
        [SerializeField] private float accelerationPerSecond;
        [SerializeField] private float slowdownPerSecond;
        [SerializeField] private float rotationPerSecond;
        [SerializeField] private float maxSpeed;

        public ShipMovement Movement => new ShipMovement(accelerationPerSecond, slowdownPerSecond, rotationPerSecond, maxSpeed);
    }
}
