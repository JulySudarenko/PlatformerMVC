using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public Transform EnemyPrefab;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _enemyPower;
        [SerializeField] private List<Transform> _wayPoints;

        public float Speed => _enemySpeed;
        public float EnemyPower => _enemyPower;
        public List<Transform> WayPoints => _wayPoints;
    }

}
