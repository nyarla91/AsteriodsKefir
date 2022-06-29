using Model;
using UnityEngine;
using SN = System.Numerics;

namespace View.Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerUI))]
    public class PlayerView : CollidingView
    {
        [Header("Movement")]
        [SerializeField] private float _acceleration = 0.1f;
        [SerializeField] private float _deacceleration = 0.03f;
        [Tooltip("Units/Second")] [SerializeField] private float _movementSpeed = 4; // units/second
        [Tooltip("Degrees/Second")] [SerializeField] private float _rotationSpeed = 120; // degrees/second
        [Header("Attack")]
        [SerializeField] private float _cannonPeriod = 0.5f;
        [SerializeField] private int _laserCharges = 3;
        [Tooltip("Charges/Second")] [SerializeField] private float _laserChargesRestorationSpeed = 0.3f; 
        
        private PlayerInput _input;
        private PlayerUI _ui;
        private PlayerAttack _attackModel;

        public PlayerAttack AttackModel => _attackModel;
        public new Model.Player Model => (Model.Player) base.Model;

        public void Initialize(Model.Player model, PlayerAttack attackModel)
        {
            base.Model = model;
            _attackModel = attackModel;
            AddUpdatable(attackModel);
            OnValidate();

            _input = GetComponent<PlayerInput>();
            _input.Initialize(this);
            
            _ui = GetComponent<PlayerUI>();
            _ui.Initialize(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            _attackModel = null;
        }

        private void OnValidate()
        {
            Model?.UpdateStats(_acceleration, _deacceleration, _movementSpeed, _rotationSpeed);
            AttackModel?.UpdateStats(_cannonPeriod, _laserCharges, _laserChargesRestorationSpeed);
        }
    }
}
