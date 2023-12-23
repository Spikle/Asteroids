using Asteroids.Core.Gameplay.Weapon;
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

        public LaserWeaponConfig Config => new LaserWeaponConfig(maxBullets, shootTime, cooldawnTime, laserLength);
    }
}
