using static Platformer.Extentions;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public GameObject EnemySimplePrefab;
        public LevelObjectTrigger ProtectedZone;
        [SerializeField] private string _enemyAnimeCnfPath;
        [SerializeField] private List<Transform> _wayPoints;
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _enemyAnimationSpeed;
        [SerializeField] private float _enemyPower;
        [SerializeField] private float _minDistanceToTarget;
        
        private SpriteAnimatorConfig _enemyAnimatorCnf;
        
        public List<Transform> WayPoints => _wayPoints;
        public float EnemySpeed => _enemySpeed;
        public float EnemyAnimationSpeed => _enemyAnimationSpeed;
        public float EnemyPower => _enemyPower;
        public float MINDistanceToTarget => _minDistanceToTarget;
        
        public SpriteAnimatorConfig EnemyAnimatorCnf
        {
            get
            {
                if (_enemyAnimatorCnf == null)
                {
                    _enemyAnimatorCnf = Load<SpriteAnimatorConfig>("Anime/" + _enemyAnimeCnfPath);
                }
        
                return _enemyAnimatorCnf;
            }
        }
    }
}
