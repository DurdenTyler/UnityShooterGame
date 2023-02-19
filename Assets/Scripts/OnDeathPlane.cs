using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class OnDeathPlane : MonoBehaviour
    {
        [SerializeField] private GameObject DeathPlane;
        
        // Рестарт уровня если игрок попал за пределы уровня
        private void OnCollisionEnter(Collision collision)
        {
            GameObject deathLand = Instantiate(DeathPlane, DeathPlane.transform);
            
            var currentScene = SceneManager.GetActiveScene().name; // получаем текущую сцену
            SceneManager.LoadSceneAsync(currentScene); // перезагружаем
        }
    }
}