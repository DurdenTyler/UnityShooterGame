using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ThrowAGranade : MonoBehaviour
    {
        [SerializeField] private float throwForce = 40;
        [SerializeField] private GameObject granadePrefab;
        [SerializeField] private Transform shootPoint;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                {
                    GameObject granade = Instantiate(granadePrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
                    var rigidbody = granade.GetComponent<Rigidbody>();
                    rigidbody.AddForce(shootPoint.forward * throwForce, ForceMode.VelocityChange);
                }
            }
        }
    }
}