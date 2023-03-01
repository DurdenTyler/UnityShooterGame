using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float force = 4;
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private GameObject muzzleFlashPrefab; // эффект от выстрела
        [SerializeField] private Transform shootPoint;
        [SerializeField] private float damage = 1;
        [SerializeField] private float spreadConfig = 0.1f;


        public void Shoot()
        {
            CreateMuzzleEffect();

            var direction = shootPoint.forward + SpreadCalculate.Calculate(spreadConfig);

            if (!Physics.Raycast(shootPoint.position, direction, out var hit)) return;

            SpawnImpactMethod(hit);

            TryDamageDestructableObject(hit);

            TryPushRigidBody(hit);
        }

        private void CreateMuzzleEffect()
        {
            if (muzzleFlashPrefab == null) return;
            var flashEffect = Instantiate(muzzleFlashPrefab, shootPoint);
                Destroy(flashEffect, 0.2f);
        }

        private void TryPushRigidBody(RaycastHit hit)
        {
            var rigidbody = hit.transform.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                rigidbody.AddForce(shootPoint.forward * force, ForceMode.Impulse);
            }
        }

        private void TryDamageDestructableObject(RaycastHit hit)
        {
            var destructible = hit.transform.GetComponent<DestractibleObject>();

            if (destructible != null)
            {
                destructible.ReceiveDamage(damage);
            }
        }

        private void SpawnImpactMethod(RaycastHit hit)
        {
            var impact = Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
            Destroy(impact, 0.5f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(shootPoint.position, shootPoint.forward*9999);
        }
    }
}