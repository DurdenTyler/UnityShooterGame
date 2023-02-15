using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BurningGrenade : MonoBehaviour
    {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private float delay = 3f;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float force = 500f;
        private float countdown;
        private bool hasExplode = false;

        private void Start()
        {
            countdown = delay;
        }

        void Update()
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && !hasExplode)
            {
                Explode();
                hasExplode = true;
            }
        }

        void Explode()
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider i in colliders)
            {
                var rigidbody = i.GetComponent<Rigidbody>();
                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(force, transform.position, radius);
                }
            }
            
            Destroy(gameObject);
            Destroy(explosionEffect);
        }

    }
}