using System;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Asteroids.Core.Spawners
{
    public class BulletSpawner : Spawner
    {
        private BulletMovement bulletMovement;
        private Func<Vector, float, bool> pointOutsideWorld;

        public BulletSpawner(BulletMovement bulletMovement, Func<Vector, float, bool> pointOutsideWorld)
        {
            this.bulletMovement = bulletMovement;
            this.pointOutsideWorld = pointOutsideWorld;
        }

        public override bool CanSpawn()
        {
            return true;
        }

        public override Transform Spawn(Vector position, float rotation)
        {
            Bullet asteroid = new Bullet(bulletMovement.Size, bulletMovement.Speed, position, rotation, pointOutsideWorld);
            return asteroid;
        }

        public override void Tick(float deltaTime)
        {
            
        }
    }
}

