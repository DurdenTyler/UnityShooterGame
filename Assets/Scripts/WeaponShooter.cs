using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponShooter: MonoBehaviour
    {

        [SerializeField] private WeaponSwap _weaponSwap;
        private void Update()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            _weaponSwap.CurrentWeapon.Shoot();
        }
    }
}