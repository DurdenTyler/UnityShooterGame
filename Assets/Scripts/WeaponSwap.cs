using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwap : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;
        
        public Weapon CurrentWeapon { get; private set; } // получить может кто угодно, изменить можно только в классе WeaponSwap

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetWeapon(0);
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetWeapon(1);
            } else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetWeapon(2);
            } else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SetWeapon(3);
            }
        }
        
        private void SetWeapon(int weaponNumber)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                GameObject currentWeapon = weapons[i];

                if (i == weaponNumber)
                {
                    CurrentWeapon = currentWeapon.GetComponent<Weapon>();
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
            }
        }
    }
}