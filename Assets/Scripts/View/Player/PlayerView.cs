using System;
using Extentions;
using Model;
using UnityEngine;
using SN = System.Numerics;

namespace View.Player
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerView : TransformableView<PlayerMovement>
    {
        private PlayerInput _input;

        public PlayerMovement MovementModel => Model;

        public void Initialize(PlayerMovement movementModel)
        {
            Model = movementModel;
            fixedUpdatable = Model;

            _input = GetComponent<PlayerInput>();
            _input.Initialize(this);
        }
    }
}
