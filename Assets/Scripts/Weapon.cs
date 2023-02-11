using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float force = 4;
        // Для того что бы поле было видно в инспекторе делаем переменную либо public либо [SerializeField] private
        // [SerializeField] заставляет инспектор принудительно сериализовать поле которое является приватным
        // Когда использовать то а когда это, ответ прост никогда не использовать public
        [SerializeField] private GameObject impactPrefab;
        [SerializeField] private Transform shootPoint; // Поле что будет определять направление выстрела
        [SerializeField] private float damage = 1;
    
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) //  Нажимание левой кнопкой мыши
            {
                if (Physics.Raycast(shootPoint.position, shootPoint.forward, out var hit))
                    // transform.forward направление куда смотрит камера
                    // hit возвращает обьект по которому тыкнули
                {
                    print(hit.transform.gameObject.name); // тут выводим имя обьекта по которому тыкнули

                    Instantiate(impactPrefab, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up)); 
                    // добавление в сцену с параметрами (создать что то, где на какой точке, направление в котором он смотрит)

                    var destructible = hit.transform.GetComponent<DestractibleObject>();

                    if (destructible != null)
                    {
                        destructible.ReceiveDamage(damage);
                    }

                    var rigidbody = hit.transform.GetComponent<Rigidbody>(); // взяли у нашего обьекта компонент RigidBody

                    if (rigidbody != null)
                    {
                        rigidbody.AddForce(shootPoint.forward*force, ForceMode.Impulse); // применили к обьекту импульс
                        // hit.transform.gameObject.SetActive(false); отключаем обьект то есть убираем галочку
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