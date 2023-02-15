using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public void Load()
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
        
        // Вопрос, как правильно осуществить выход из Меню Настроек в Главное меню, я сделал это путем очередной загрузки Главного меню прост,
        // Но наверное есть метод что закрывает текущую сцену и переносит на сцену назад? 
        // Почему не гуглю? Все вспешке делаю
    }
}