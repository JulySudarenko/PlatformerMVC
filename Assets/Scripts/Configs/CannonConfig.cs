using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "CannonConfig", menuName = "Configs/CannonConfig", order = 0)]
    public class CannonConfig : ScriptableObject
    {
        public GameObject CannonPrefab;
        public Transform Turret;
        public Transform Barrel;
        public GameObject CorePrefab;
        public LayerMask Mask;

        [SerializeField, Range(1, 5000)] private float _coreForce = 9.0f;
        [SerializeField, Range(1, 100)] private float _corePower = 1.0f;
        [SerializeField, Range(1, 1)] private float _groundLevel = 0.2f;
        [SerializeField, Range(-20, 1)] private float _gravityForce = -5.0f;
        [SerializeField, Range(1, 10)] private float _spawnCoreTime = 2.0f;
        [SerializeField, Range(1, 20)] private float _lifeCoreTime = 5.0f;
        [SerializeField, Range(1, 50)] private int _corePoolSize = 5;
        

        public float Force => _coreForce;
        public float Power => _corePower;
        public float GroundLevel => _groundLevel;
        public float GravityForce => _gravityForce;
        public float SpawnCoreTime => _spawnCoreTime;
        public float LifeCoreTime => _lifeCoreTime;
        public int PoolSize => _corePoolSize;
    }
}
