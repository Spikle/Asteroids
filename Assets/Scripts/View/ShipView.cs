using Asteroids.Core.Gameplay.Player;
using Asteroids.Core.Gameplay.Player.Weapon;
using UnityEngine;

namespace Scripts.View
{
    public class ShipView : TransformView
    {
        private Ship ship;
        private InputControls input;
        private bool isActive;

        protected override void Awake()
        {
            base.Awake();
            input = new InputControls();
            input.Gameplay.Disable();
            input.UI.Disable();
        }

        public override void SetTransform(Asteroids.Core.Transform transformObject)
        {
            base.SetTransform(transformObject);
            ship = (Ship)transformObject;
            ship.WeaponController.OnShoot += Shoot;
            ship.WeaponController.OnUpdateWeapon += UpdateWeapon;
        }

        public void SetActive(bool value)
        {
            isActive = value;
            if(isActive)
            {
                input.Gameplay.Enable();
            }else
            {
                input.Gameplay.Disable();
            }
        }

        private void Update()
        {
            if (ship == null)
                return;

            if (!isActive)
                return;

            Vector2 inputKayboard = input.Gameplay.Movement.ReadValue<Vector2>();

            float dir = inputKayboard.y;
            float rot = inputKayboard.x;
            bool defoultAttack = input.Gameplay.DefaultAttack.triggered;
            bool specialAttack = input.Gameplay.SpecialAttack.triggered;
            ship.Input(new Asteroids.Core.Gameplay.Player.Input(dir, rot, defoultAttack, specialAttack));
        }

        protected override void LateUpdate()
        {
            base.LateUpdate();
            EventBusSystem.EventBus.RaiseEvent<IShipUIHandler>(h=> h.UpdateShip(new Vector2(ship.Position.x, ship.Position.y), ship.Rotation, ship.Acceleration));
        }

        private void Shoot(int index, WeaponInfo weapon)
        {
            if(index == 1)
            {
                EventBusSystem.EventBus.RaiseEvent<IShipUIHandler>(h => h.UpdateLaser(weapon));
            }
        }

        private void UpdateWeapon(int index, WeaponInfo weapon)
        {
            if (index == 1)
            {
                EventBusSystem.EventBus.RaiseEvent<IShipUIHandler>(h => h.UpdateLaser(weapon));
            }
        }

        private void OnDestroy()
        {
            if(ship != null)
            {
                ship.WeaponController.OnUpdateWeapon -= UpdateWeapon;
                ship.WeaponController.OnShoot -= Shoot;
            }

            input.Dispose();
        }
    }
}
