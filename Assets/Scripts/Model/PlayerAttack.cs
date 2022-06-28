using System;
using Model.Bullets;
using UnityEngine;

namespace Model
{
    public class PlayerAttack : IFixedUpdatable
    {
        private const float CannonPeriod = 0.5f;
        private const int LaserCharges = 3;
        private const float LaserChargesRestorationSpeed = 0.3f; // charges/second
        
        private readonly PlayerMovement _movement;
        private Bullet[] _weapons;

        private float _cannonCooldownLeft;
        private bool _isCannonShooting;
        private float _laserChargesLeft;

        public event Action<Bullet> OnShoot; 

        public PlayerAttack(PlayerMovement movement)
        {
            _movement = movement;
        }

        public void FixedUpdate(float deltaTime)
        {
            Debug.Log(_laserChargesLeft);
            if (_isCannonShooting)
                ShootCannon();
            _cannonCooldownLeft = Math.Max(_cannonCooldownLeft - deltaTime, 0);

            _laserChargesLeft = Math.Min(_laserChargesLeft + LaserChargesRestorationSpeed * deltaTime, LaserCharges);
        }

        public void StartCannonShooting() => _isCannonShooting = true;

        public void EndCannonShooting() => _isCannonShooting = false;

        public void ShootLaser()
        {
            if (_laserChargesLeft < 1)
                return;

            OnShoot?.Invoke(new LaserBullet(_movement.Position, _movement.Rotation));
            _laserChargesLeft -= 1;
        }

        private void ShootCannon()
        {
            if (_cannonCooldownLeft > 0)
                return;
            
            OnShoot?.Invoke(new CannonBullet(_movement.Position, _movement.Rotation));
            _cannonCooldownLeft = CannonPeriod;
        }
    }
}