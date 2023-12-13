using System;

namespace Asteroids.Core.Gameplay.Player.Weapon
{
    public class ShipWeaponController
    {
        public event Action<int, WeaponInfo> OnShoot;
        public event Action<int, WeaponInfo> OnUpdateWeapon;

        private AbstractWeapon[] slots;

        public ShipWeaponController()
        {
            this.slots = new AbstractWeapon[2];
        }

        public ShipWeaponController(AbstractWeapon firstWeapon, AbstractWeapon secondWeapon)
        {
            this.slots = new AbstractWeapon[2] { firstWeapon, secondWeapon};
        }

        public void AddMainWeapon(AbstractWeapon weapon)
        {
            slots[0] = weapon;
            weapon.OnUpdateState += UpdateWeapon;
            UpdateWeapon(weapon);
        }

        public void AddAdditiveWeapon(AbstractWeapon weapon)
        {
            slots[1] = weapon;
            weapon.OnUpdateState += UpdateWeapon;
            UpdateWeapon(weapon);
        }

        public void Tick(float deltaTime)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].Tick(deltaTime);
            }
        }

        public bool CanShootMainWeapon()
        {
            if (slots[0] == null)
                return false;

            return slots[0].CanShoot();
        }

        public bool CanShootAdditiveWeapon()
        {
            if (slots[1] == null)
                return false;

            return slots[1].CanShoot();
        }

        public void ShootMainWeapon(Vector start, Vector direction)
        {
            if(slots[0] != null)
            {
                slots[0].Shoot(start, direction);
                OnShoot?.Invoke(0, slots[0].GetInfo());
            }
        }

        public void ShootAdditiveWeapon(Vector start, Vector direction)
        {
            if (slots[1] != null)
            {
                slots[1].Shoot(start, direction);
                OnShoot?.Invoke(1, slots[1].GetInfo());
            }
        }

        private void UpdateWeapon(AbstractWeapon weapon)
        {
            int index = -1;
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == weapon)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
                return;

            OnUpdateWeapon?.Invoke(index, weapon.GetInfo());
        }
    }
}
