using UnityEngine;
using UnityEngine.InputSystem;

namespace View.Player
{
    public class PlayerInput : MonoBehaviour
    {
        private PlayerView _view;
        private PlayerActions _actions;
        
        public void Initialize(PlayerView view)
        {
            _view = view;
            _actions = new PlayerActions();
            _actions.Enable();
            _actions.Gameplay.Accelerate.started += ModelStartAcceleration;
            _actions.Gameplay.Accelerate.canceled += ModelEndAcceleration;
            _actions.Gameplay.CannonShoot.started += ModelStartCannonShooting;
            _actions.Gameplay.CannonShoot.canceled += ModelEndCannonShooting;
            _actions.Gameplay.LaserShoot.performed += ModelShootLaser;
        }

        private void ModelEndAcceleration(InputAction.CallbackContext context) => _view.Model?.EndAcceleration();
        private void ModelStartAcceleration(InputAction.CallbackContext context) => _view.Model?.StartAcceleration();
        private void ModelStartCannonShooting(InputAction.CallbackContext context) => _view.AttackModel.StartCannonShooting();
        private void ModelEndCannonShooting(InputAction.CallbackContext context) => _view.AttackModel.EndCannonShooting();
        private void ModelShootLaser(InputAction.CallbackContext context) => _view.AttackModel.ShootLaser();

        private void FixedUpdate()
        {
            if (_actions == null)
                return;
            float rotationAxis = _actions.Gameplay.Rotate.ReadValue<float>();
            _view.Model?.Rotate(Time.fixedDeltaTime, rotationAxis);
        }

        private void OnDestroy()
        {
            _actions.Gameplay.Accelerate.started -= ModelStartAcceleration;
            _actions.Gameplay.Accelerate.canceled -= ModelEndAcceleration;
            _actions.Gameplay.CannonShoot.started -= ModelStartCannonShooting;
            _actions.Gameplay.CannonShoot.canceled -= ModelEndCannonShooting;
            _actions.Gameplay.LaserShoot.performed -= ModelShootLaser;
        }
    }
}