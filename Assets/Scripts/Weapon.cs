using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float force = 4;
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float damage = 1;
        [SerializeField] private float spreadConfig = 0.1f;


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {

                var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
                var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);

                var spread = new Vector3(x: randomX, y: randomY, z: 0f);
                var direction = shootPoint.forward + spread;

                if (Physics.Raycast(shootPoint.position, direction, out var hit))
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