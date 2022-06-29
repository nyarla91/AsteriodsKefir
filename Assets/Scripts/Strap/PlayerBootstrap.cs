using Model;
using UnityEngine;
using View;
using View.Player;
using SN = System.Numerics;
using Vector3 = UnityEngine.Vector3;

namespace Strap
{
    public class PlayerBootstrap : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private BulletFactory _bulletFactory;
        [SerializeField] private PlayerView _view;
        
        private void Awake()
        {
            SN.Vector2 position = _view.Transform.position.ToSystemVector().To2();
            SN.Vector2 scale = _view.Transform.localScale.ToSystemVector().To2();
            float rotation = _view.Transform.rotation.eulerAngles.z;
            SN.Vector2 minCameraBounds = _camera.ScreenToWorldPoint(Vector3.zero).ToSystemVector().To2();
            SN.Vector2 maxCameraBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).ToSystemVector().To2();
            Player model = new Player(position, rotation, scale, maxCameraBounds, minCameraBounds);

            PlayerAttack attackModel = new PlayerAttack(model);
            attackModel.OnShoot += _bulletFactory.InstantiateBullet;
            
            _view.Initialize(model, attackModel);
        }
    }
}