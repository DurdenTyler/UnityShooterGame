using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponSwap : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;


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
            }
        }
        
        private void SetWeapon(int weaponNumber)
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == weaponNumber)
                {
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