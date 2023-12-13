using Asteroids.Core.Gameplay.Player.Weapon;
using UnityEngine;

namespace Scripts.View
{
    [CreateAssetMenu(fileName = "Laser Data", menuName = "Objects/Laser", order = 4)]
    public class LaserData : ScriptableObject
    {
        [SerializeField] private int maxBullets;
        [SerializeField] private float shootTime;
        [SerializeField] private float cooldawnTime;
        [SerializeField] private float laserLength;

        public LaserConfig Config => new LaserConfig(maxBullets, shootTime, cooldawnTime, laserLength);
    }
}
