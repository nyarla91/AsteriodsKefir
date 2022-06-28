using System;
using Model.Bullets;

namespace Model
{
    public class PlayerAttack : IFixedUpdatable
    {
        private float _cannonPeriod = 0.5f;
        private int _laserCharges = 3;
        private float _laserChargesRestorationSpeed = 0.3f; // charges/second
        
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

        public void UpdateStats(float cannonPeriod, int laserCharges, float laserChargesRestorationSpeed)
        {
            _cannonPeriod = cannonPeriod;
            _laserCharges = laserCharges;
            _laserChargesRestorationSpeed = laserChargesRestorationSpeed;
        }

        public void FixedUpdate(float deltaTime)
        {
            if (_isCannonShooting)
                ShootCannon();
            _cannonCooldownLeft = Math.Max(_cannonCooldownLeft - deltaTime, 0);

            _laserChargesLeft = Math.Min(_laserChargesLeft + _laserChargesRestorationSpeed * deltaTime, _laserCharges);
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
            _cannonCooldownLeft = _cannonPeriod;
        }
    }
}