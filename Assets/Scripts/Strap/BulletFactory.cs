﻿using Extentions;
using Model.Bullets;
using UnityEngine;
using View;

namespace Strap
{
    public class BulletFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _bulletPrefab;
        
        public void InstantiateBullet(Bullet bullet)
        {
            BulletView view = Instantiate(_bulletPrefab, bullet.Position.ToUnityVector(), Quaternion.Euler(0, 0, bullet.Rotation))
                .GetComponent<BulletView>();
            
            view.Initialize(bullet);
        }
    }
}