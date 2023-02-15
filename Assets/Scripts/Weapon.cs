using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float force = 4;
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float damage = 1;


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                {

                    var impact = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                    Destroy(impact, 0.5f);

                    var destructible = hit.transform.GetComponent<DestractibleObject>();

                    if (destructible != null)
                    {
                        destructible.ReceiveDamage(damage);
                    }

                    var rigidbody = hit.transform.GetComponent<Rigidbody>();

                    if (rigidbody != null)
                    {
                        rigidbody.AddForce(shootPoint.forward*force, ForceMode.Impulse);
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(shootPoint.position, shootPoint.forward*9999);
        }
    }
}