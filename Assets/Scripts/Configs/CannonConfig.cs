using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    [CreateAssetMenu(fileName = "CannonConfig", menuName = "Configs/CannonConfig", order = 0)]
    public class CannonConfig : ScriptableObject
    {
        public GameObject CannonPrefab;
        public GameObject CorePrefab;
        public LayerMask Mask;

        [SerializeField, Range(1, 5000)] private float _coreForce;
        [SerializeField, Range(1, 100)] private float _corePower;
        [SerializeField] private float _groundLevel = 0.3f;
        [SerializeField] private float _gravityForce = -5f;
        [FormerlySerializedAs("_spawpCoreTime")] [SerializeField] private float _spawnCoreTime = 2.0f;
        [SerializeField, Range(1, 50)] private int _corePoolSize;

        public float Force => _coreForce;
        public float Power => _corePower;
        public float GroundLevel => _groundLevel;
        public float GravityForce => _gravityForce;
        public float SpawnCoreTime => _spawnCoreTime;
        public int PoolSize => _corePoolSize;
    }
}
