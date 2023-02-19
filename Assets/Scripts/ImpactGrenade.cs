using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ImpactGrenade : MonoBehaviour
    {
        [SerializeField] private GameObject explosionEffect;
        [SerializeField] private float radius = 5f;
        [SerializeField] private float force = 500f;
        
        // Вызывается когда rigidbody моего обьекта на котором вести этот скрипт влетел в какой то другой коллайдер
        private void OnCollisionEnter(Collision collision)
        {
            Explode();
        }

        // Вызывается когда обьекты разомкнулись
        private void OnCollisionExit(Collision other)
        {
            
        }

        // На кажлм апдейте когда обьекты соприкасаются (На каждом кадре после столкновения)
        private void OnCollisionStay(Collision collisionInfo)
        {
            
        }
        
        void Explode()
        {
            var explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion, 2f);

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
        }
        
        
    }
}