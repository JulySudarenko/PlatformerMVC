using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public Transform EnemyPrefab;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _enemyPower;

        public float EnemySpeed => _enemySpeed;
        public float EnemyPower => _enemyPower;
    }

}
