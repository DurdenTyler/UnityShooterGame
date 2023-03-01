using UnityEngine;

namespace DefaultNamespace
{
    public static class SpreadCalculate
    {
        public static Vector3 Calculate(float spreadConfig)
        {
            var randomX = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var randomY = Random.Range(-spreadConfig / 2, spreadConfig / 2);
            var spread = new Vector3(x: randomX, y: randomY, z: 0f);
            return spread;
        }
    }
}