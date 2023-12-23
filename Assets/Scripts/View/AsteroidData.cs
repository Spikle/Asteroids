using Asteroids.Core.Gameplay.Enemy;
using UnityEngine;

namespace Scripts.View
{
    [CreateAssetMenu(fileName = "Asteroid Data", menuName = "Objects/Asteroid", order = 1)]
    public class AsteroidData : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;
        [SerializeField] private float size;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float maxRotation;
        [SerializeField][Range(0.1f, 25f)] private float timeCooldawnSpawn;
        [SerializeField] private int countMiniAsteroids;
        [SerializeField] private int scoreOnDead;

        public Asteroids.Core.Gameplay.Enemy.AsteroidData Movement => new Asteroids.Core.Gameplay.Enemy.AsteroidData(size, minSpeed, maxSpeed, maxRotation, timeCooldawnSpawn, countMiniAsteroids, scoreOnDead);

        public Sprite GetSprite()
        {
            if (sprites.Length == 0)
                return null;

            return sprites[Random.Range(0, sprites.Length)];
        }
    }
}

