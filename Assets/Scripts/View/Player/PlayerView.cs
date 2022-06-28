using Model;
using UnityEngine;
using SN = System.Numerics;

namespace View.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerView : TransformableView<PlayerMovement>
    {
        private PlayerInput _input;
        private PlayerAttack _attackModel;

        public PlayerAttack AttackModel => _attackModel;
        public PlayerMovement MovementModel => Model;

        public void Initialize(PlayerMovement movementModel, PlayerAttack attackModel)
        {
            Model = movementModel;
            fixedUpdatables.Add(Model);
            _attackModel = attackModel;
            fixedUpdatables.Add(attackModel);

            _input = GetComponent<PlayerInput>();
            _input.Initialize(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _attackModel = null;
        }
    }
}
