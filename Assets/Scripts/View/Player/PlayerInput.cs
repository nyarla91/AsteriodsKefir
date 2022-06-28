using UnityEngine;
using UnityEngine.InputSystem;

namespace View.Player
{
    [RequireComponent(typeof(PlayerView))]
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
        }

        private void ModelEndAcceleration(InputAction.CallbackContext context) => _view.MovementModel.EndAcceleration();
        private void ModelStartAcceleration(InputAction.CallbackContext context) => _view.MovementModel.StartAcceleration();

        private void FixedUpdate()
        {
            if (_actions == null)
                return;
            float rotationAxis = _actions.Gameplay.Rotate.ReadValue<float>();
            _view.MovementModel.Rotate(Time.fixedDeltaTime, rotationAxis);
        }

        private void OnDestroy()
        {
            _actions.Gameplay.Accelerate.started -= ModelStartAcceleration;
            _actions.Gameplay.Accelerate.canceled -= ModelEndAcceleration;
        }
    }
}