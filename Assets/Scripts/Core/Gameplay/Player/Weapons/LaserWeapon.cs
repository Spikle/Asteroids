using System;

namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class LaserWeapon : AbstractWeapon
    {
        private LaserConfig config;
        private bool isActive;
        private int countShoots;

        private float timeCooldownResetShoots;
        private float timeCooldawnShoot;

        public LaserWeapon(Transform owner, LaserConfig config, Action<Vector, Vector> shoot) : base(owner, shoot)
        {
            this.config = config;
        }

        public LaserWeapon(Transform owner, LaserConfig config, Action<Vector, Vector> shoot, Action startShoot, Action endShoot) : base(owner, shoot, startShoot, endShoot)
        {
            this.config = config;
        }

        public override void Tick(float deltaTime)
        {
            if(isActive)
            {
                timeCooldawnShoot -= deltaTime;

                if(timeCooldawnShoot > 0)
                {
                    OnShootEvent(owner.Position, owner.Forward * config.LaserLength);
                }
                else
                {
                    isActive = false;
                    OnEndShootEvent();
                }
            }

            if(countShoots < config.MaxBullets)
            {
                timeCooldownResetShoots -= deltaTime;
                if (timeCooldownResetShoots <= 0)
                {
                    countShoots++;
                    countShoots = Math.Clamp(countShoots, 0, config.MaxBullets);
                    timeCooldownResetShoots = config.CooldawnTime;
                }

                OnUpdateStateEvent();
            }
        }

        public override bool CanShoot()
        {
            return countShoots > 0 && !isActive;
        }

        public override void Shoot(Vector start, Vector direction)
        {
            if (CanShoot())
            {
                OnStartShootEvent();
                OnShootEvent(start, direction * config.LaserLength);
                countShoots--;
                isActive = true;
                timeCooldawnShoot = config.ShootTime;
                OnUpdateStateEvent();
            }
        }

        public override WeaponInfo GetInfo()
        {
            return new LaserInfo(countShoots, config.MaxBullets, timeCooldownResetShoots);
        }
    }

    public class LaserInfo : WeaponInfo
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

        public override string GetInfo()
        {
            string info = $"{countShoots}/{maxCountShoots}";
            if(countShoots < maxCountShoots)
            {
                info += $" ({timeCooldawn.ToString("0.00")}s)";
            }

            return info;
        }
    }
}

