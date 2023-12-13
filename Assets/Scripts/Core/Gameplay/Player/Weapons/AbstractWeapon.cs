using System;

namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public abstract class AbstractWeapon
    {
        public event Action OnStartShoot;
        public event Action<Vector, Vector> OnShoot;
        public event Action<AbstractWeapon> OnUpdateState;
        public event Action OnEndShoot;

        protected Transform owner;

        public AbstractWeapon(Transform owner, Action<Vector, Vector> shoot)
        {
            OnShoot += shoot;
            this.owner = owner;
        }

        public AbstractWeapon(Transform owner, Action<Vector, Vector> shoot, Action startShoot, Action endShoot)
        {
            OnStartShoot += startShoot;
            OnShoot += shoot;
            OnEndShoot += endShoot;
            this.owner = owner;
        }

        public virtual void Tick(float deltaTime)
        {

        }

        public abstract bool CanShoot();

        public virtual void Shoot(Vector start, Vector direction)
        {
            if(CanShoot())
            {
                OnShootEvent(start, direction);
            }
        }

        protected virtual void OnUpdateStateEvent()
        {
            OnUpdateState?.Invoke(this);
        }

        protected virtual void OnStartShootEvent()
        {
            OnStartShoot?.Invoke();
        }

        protected virtual void OnShootEvent(Vector start, Vector direction)
        {
            OnShoot?.Invoke(start, direction);
        }

        protected virtual void OnEndShootEvent()
        {
            OnEndShoot?.Invoke();
        }

        public virtual WeaponInfo GetInfo()
        {
            return new WeaponInfo();
        }
    }

    public class WeaponInfo
    {
        public virtual string GetInfo()
        {
            return "";
        }
    }
}
