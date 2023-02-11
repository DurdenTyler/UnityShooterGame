using UnityEngine;

namespace DefaultNamespace
{
    public class DestractibleObject : MonoBehaviour
    {
        [SerializeField] private float hpInitial = 100;
        [SerializeField] private float hpCurrent = 100;
        
        public void ReceiveDamage()
        {
            hpCurrent -= 26f;

            if (hpCurrent < 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}