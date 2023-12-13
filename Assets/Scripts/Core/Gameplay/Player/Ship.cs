using System;
using Asteroids.Core.Collision;
using Asteroids.Core.Gameplay.Enemy;
using Asteroids.Core.Gameplay.Player.Weapon;

namespace Asteroids.Core.Gameplay.Player
{
    public class Ship : Transform, ITickable, ICollider
    {
        public event Action<ITickable> OnDestroy;

        private float acceleration;
        private ShipMovement movement;
        private Func<Vector, float, Vector> calculateBorderWorld;
        private ShipWeaponController weapons;

        private float directionInput;
        private float rotationInput;
        private bool defoultAttackInput;
        private bool specialAttackInput;

        private float size;

        public float Acceleration => acceleration;
        public float Size => size;
        public Vector Center => Position;

        public ShipWeaponController WeaponController => weapons;

        public Ship(Vector position, float rotation, ShipMovement movement, Func<Vector, float, Vector> calculateBorderWorld) : base(position, rotation)
        {
            directionInput = 0;
            rotationInput = 0;
            defoultAttackInput = false;
            specialAttackInput = false;
            this.movement = movement;
            this.calculateBorderWorld = calculateBorderWorld;
            weapons = new ShipWeaponController();
        }

        public void AddMainWeapon(AbstractWeapon weapon)
        {
            weapons.AddMainWeapon(weapon);
        }

        public void AddAdditiveWeapon(AbstractWeapon weapon)
        {
            weapons.AddAdditiveWeapon(weapon);
        }

        public void Input(Input input)
        {
            directionInput = input.Direction;
            rotationInput = input.Rotation;
            defoultAttackInput = input.DefoultAttack;
            specialAttackInput = input.SpecialAttack;
        }

        public void Tick(float deltaTime)
        {
            Move(deltaTime);
            Rotate(rotationInput * movement.RotationPerSecond * deltaTime);
            weapons.Tick(deltaTime);
            Attack();
        }

        private void Move(float deltaTime)
        {
            Slowdown(deltaTime);
            Accelerate(deltaTime);
            Vector delta = Forward * acceleration;
            var nextPosition = Position + delta;
            Position = calculateBorderWorld.Invoke(nextPosition, 0);
        }

        private void Accelerate(float deltaTime)
        {
            acceleration += directionInput * movement.AccelerationPerSecond * deltaTime;
            acceleration = Math.Clamp(acceleration, 0, movement.MaxSpeed);
        }

        private void Slowdown(float deltaTime)
        {
            acceleration -= movement.SlowdownPerSecond * deltaTime;
            acceleration = Math.Clamp(acceleration, 0, movement.MaxSpeed);
        }

        private void Attack()
        {
            if(defoultAttackInput)
            {
                if(weapons.CanShootMainWeapon())
                {
                    weapons.ShootMainWeapon(Position, Forward);
                }
            }

            if(specialAttackInput)
            {
                if (weapons.CanShootAdditiveWeapon())
                {
                    weapons.ShootAdditiveWeapon(Position, Forward);
                }
            }
        }

        public void OnColliderHit(ICollider other)
        {
            if(other is AbstractEnemy)
            {
                OnDestroy?.Invoke(this);
            }
        }

        public void OnLineHit(ICollider owner)
        {
           
        }
    }
}
