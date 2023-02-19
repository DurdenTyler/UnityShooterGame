using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class BackToLastScene : MonoBehaviour
    {
        [SerializeField] private string _lastSceneName;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync(_lastSceneName);
            }
        }
    }
}