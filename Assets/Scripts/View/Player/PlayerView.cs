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

        private void Awake()
        {
            SN.Vector2 position = Transform.position.ToSystemVector().To2();
            SN.Vector2 scale = Transform.localScale.ToSystemVector().To2();
            float rotation = Transform.rotation.eulerAngles.z;
            Model = new PlayerMovement(position, scale, rotation);
            fixedUpdatable = Model;
        }
    }
}
