using Extentions;
using Model;
using SN = System.Numerics;

namespace View.Player
{
    public class PlayerView : TransformableView<PlayerMovement>
    {
        private void Awake()
        {
            SN.Vector2 position = Transform.position.ToSystemVector().To2();
            SN.Vector2 scale = Transform.localScale.ToSystemVector().To2();
            float rotation = Transform.rotation.eulerAngles.z;
            Model = new PlayerMovement(position, scale, rotation);
        }
    }
}
