using Asteroids.Core.Gameplay.Enemy;
using UnityEngine;

namespace Scripts.View
{
    [CreateAssetMenu(fileName = "Nlo Data", menuName = "Objects/Nlo", order = 3)]
    public class NloData : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float size;
        [SerializeField] private float speed;
        [SerializeField][Range(0.1f, 25f)] private float timeCooldawnSpawn;
        [SerializeField] private int scoreOnDead;

        public Asteroids.Core.Gameplay.Enemy.NloData Movement => new Asteroids.Core.Gameplay.Enemy.NloData(size, speed, timeCooldawnSpawn, scoreOnDead);

        public Sprite GetSprite()
        {
            if (sprites.Length == 0)
                return null;

            return sprites[Random.Range(0, sprites.Length)];
        }
    }
}


