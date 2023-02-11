using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTest : MonoBehaviour
{
    
    [SerializeField] private float force = 10;
    // Для того что бы поле было видно в инспекторе делаем переменную либо public либо [SerializeField] private
    // [SerializeField] заставляет инспектор принудительно сериализовать поле которое является приватным
    // Когда использовать то а когда это, ответ прост никогда не использовать public
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //  Нажимание левой кнопкой мыши
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit))
                // transform.forward направление куда смотрит камера
                // hit возвращает обьект по которому тыкнули
            {
                print(hit.transform.gameObject.name); // тут выводим имя обьекта по которому тыкнули

                var rigidbody = hit.transform.GetComponent<Rigidbody>(); // взяли у нашего обьекта компонент RigidBody

                if (rigidbody == null)
                {
                    // hit.transform.gameObject.SetActive(false); отключаем обьект то есть убираем галочку
                    return;
                }
                
                rigidbody.AddForce(transform.forward*force, ForceMode.Impulse); // применили к обьекту импульс
            }
        }
    }
}
