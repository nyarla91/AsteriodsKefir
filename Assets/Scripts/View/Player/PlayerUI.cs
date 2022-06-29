using System;
using Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = System.Numerics.Vector2;

namespace View.Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _transformInfo;
        [SerializeField] private TMP_Text _movementInfo;
        [SerializeField] private TMP_Text _laserChargesCounter;
        [SerializeField] private Image _laserCooldownRing;
        
        public void Initialize(PlayerView view)
        {
            view.Model.OnTransformed += UpdateTransformable;
            view.Model.OnVelocityChanged += UpdateVelocity;
            view.AttackModel.OnLaserChargesChanged += UpdateLaserCharges;
        }

        private void UpdateLaserCharges(float charge)
        {
            int fullCharges = (int) charge;
            float cooldown = charge % 1;
            _laserChargesCounter.text = fullCharges.ToString();
            _laserCooldownRing.fillAmount = cooldown;
        }

        private void UpdateVelocity(Vector2 velocity)
        {
            velocity /= Time.deltaTime;
            _movementInfo.text = $"Velocity: {SystemVector2ToString(velocity)}, Speed: {LimitDigits(velocity.Length())}/sec";
        }

        private void UpdateTransformable(Transformable transformable)
        {
            _transformInfo.text = $"{SystemVector2ToString(transformable.Position)} | {LimitDigits(transformable.Rotation)}°";
        }

        private string SystemVector2ToString(Vector2 vector)
        {
            return $"({LimitDigits(vector.X)}; {LimitDigits(vector.Y)})";
        }

        private double LimitDigits(double value) => Math.Round(value, 1);
    }
}