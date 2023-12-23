using Asteroids.Core.Gameplay.Weapon;
using UnityEngine;

namespace Scripts.View
{
    [CreateAssetMenu(fileName = "Bullet Data", menuName = "Objects/Bullet", order = 2)]
    public class BulletData : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float size;
        [SerializeField] private float speed;

        public DefoultWeaponConfig Config => new DefoultWeaponConfig(size, speed);

        public Sprite GetSprite()
        {
            if (sprites.Length == 0)
                return null;

            return sprites[Random.Range(0, sprites.Length)];
        }
    }
}

