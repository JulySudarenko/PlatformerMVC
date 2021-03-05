using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "CannonConfig", menuName = "Configs/CannonConfig", order = 0)]
    public class CannonConfig : ScriptableObject
    {
        public GameObject CannonPrefab;
        public GameObject CorePrefab;

        [SerializeField, Range(1, 5000)] private float _coreForce;
        [SerializeField, Range(1, 100)] private float _corePower;
        [SerializeField, Range(1, 50)] private int _corePoolSize;

        public float Force => _coreForce;
        public float Power => _corePower;
        public int PoolSize => _corePoolSize;
    }
}
