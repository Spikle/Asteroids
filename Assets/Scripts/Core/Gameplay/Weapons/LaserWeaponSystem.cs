using System;
using Asteroids.Core.ECS;
using Asteroids.Core.Gameplay.Player;

namespace Asteroids.Core.Gameplay.Weapon
{
    public class LaserWeaponSystem : AbstractSystem
    {
        public event Action<LaserInfo> OnUpdateLaser;

        public LaserWeaponSystem(Action<LaserInfo> onUpdateLaser)
        {
            OnUpdateLaser = onUpdateLaser;
        }

        public override void Tick(float deltaTime)
        {
            AllEntities all = GetAllEntities().With<Transform>().With<LaserWeapon>();
            for (int i = 0; i < all.Count; i++)
            {
                var transform = all[i].GetComponent<Transform>();
                var weapon = all[i].GetComponent<LaserWeapon>();
                bool isNeedUpdate = false;

                if (weapon.Bullets < weapon.Config.MaxBullets)
                {
                    weapon.CooldawnTime -= deltaTime;

                    if (weapon.CooldawnTime <= 0)
                    {
                        weapon.CooldawnTime = weapon.Config.MaxCooldawnTime;
                        weapon.Bullets++;
                        weapon.Bullets = Math.Clamp(weapon.Bullets, 0, weapon.Config.MaxBullets);
                    }

                    isNeedUpdate = true;
                }

                if (weapon.Attack && weapon.Bullets > 0)
                {
                    all[i].AddComponent<ShootLaser>(new ShootLaser(transform, weapon.Config.MaxShootTime, weapon.Config.LaserLength));
                    weapon.Bullets--;
                    isNeedUpdate = true;
                }

                if (isNeedUpdate && all[i] is Ship)
                {
                    OnUpdateLaser?.Invoke(new LaserInfo(weapon.Bullets, weapon.Config.MaxBullets, weapon.CooldawnTime));
                }
            }
        }
    }

    public class LaserInfo
    {
        private int countShoots;
        private int maxCountShoots;
        private float timeCooldawn;

        public LaserInfo(int countShoots, int maxCountShoots, float timeCooldawn)
        {
            this.countShoots = countShoots;
            this.maxCountShoots = maxCountShoots;
            this.timeCooldawn = timeCooldawn;
        }

        public string GetInfo()
        {
            string info = $"{countShoots}/{maxCountShoots}";
            if (countShoots < maxCountShoots)
            {
                info += $" ({timeCooldawn.ToString("0.00")}s)";
            }

            return info;
        }
    }

}


