using UnityEngine;

namespace Platformer
{
    [CreateAssetMenu(fileName = "BackGroundConfig", menuName = "Configs/BackGroundConfig", order = 0)]
    public class BackGroundConfig : ScriptableObject
    {
        public GameObject BackGround;
        [SerializeField] private float _size = 20.48f;
        [SerializeField] private float _sizeCoefficient = 3.0f;
        [SerializeField] private float _speedCoefficient;
        [SerializeField] private bool _isPlaceChanging = false;
        [SerializeField] private bool _isSizeChanging = false;
        [SerializeField] private bool _isCoinPlace = false;
        [SerializeField] private bool _isDeathZone = false;

        public float SpeedCoefficient => _speedCoefficient;
        public float Size => _size;
        public float SizeCoefficient => _sizeCoefficient;
        public bool IsPlaceChanging => _isPlaceChanging;
        public bool IsSizeChanging => _isSizeChanging;
        public bool IsCoinPlace => _isCoinPlace;
        public bool IsDeathZone => _isDeathZone;
    }
}
