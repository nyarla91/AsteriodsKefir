using System;
using Model.Bullets;

namespace Model
{
    public class PlayerAttack : IFixedUpdatable
    {
        private int _laserCharges = 3;
        private float _laserChargesRestorationSpeed = 0.3f; // charges/second
        
        private readonly Player _movement;

        private bool _isCannonShooting;
        private bool _isCannonReady = true;
        private float _laserChargesLeft;

        private float LaserChargesLeft
        {
            get => _laserChargesLeft;
            set
            {
                _laserChargesLeft = value;
                OnLaserChargesChanged?.Invoke(value);
            }
        }

        private readonly Timer _cannonCooldonwTimer = new Timer(0.5f);

        public event Action<Bullet> OnShoot; 
        public event Action<float> OnLaserChargesChanged; 

        public PlayerAttack(Player movement)
        {
            _movement = movement;
            _cannonCooldonwTimer.OnExpired += () => _isCannonReady = true;
        }

        public void UpdateStats(float cannonPeriod, int laserCharges, float laserChargesRestorationSpeed)
        {
            _cannonCooldonwTimer.Duration = cannonPeriod;
            _laserCharges = laserCharges;
            _laserChargesRestorationSpeed = laserChargesRestorationSpeed;
        }

        public void FixedUpdate(float deltaTime)
        {
            if (_isCannonShooting)
                ShootCannon();
            if (!_isCannonReady)
                _cannonCooldonwTimer.Update(deltaTime);
            
            LaserChargesLeft = Math.Min(LaserChargesLeft + _laserChargesRestorationSpeed * deltaTime, _laserCharges);
        }

        public void StartCannonShooting() => _isCannonShooting = true;

        public void EndCannonShooting() => _isCannonShooting = false;

        public void ShootLaser()
        {
            if (LaserChargesLeft < 1)
                return;

            OnShoot?.Invoke(new LaserBullet(_movement));
            LaserChargesLeft -= 1;
        }

        private void ShootCannon()
        {
            if (!_isCannonReady)
                return;
            
            OnShoot?.Invoke(new CannonBullet(_movement));
            _isCannonReady = false;
        }
    }
}