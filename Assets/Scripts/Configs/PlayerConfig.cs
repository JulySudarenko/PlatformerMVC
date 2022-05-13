using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [Header ("Player")]
        public GameObject PlayerPrefab;
        public LayerMask Mask;
        [SerializeField] private string _knightAnimeCnfPath = "AnimKnightCnf";
        [SerializeField, Range(-20, 100)] private float _startPointX = -5.0f;
        [SerializeField, Range(1, 500)] private float _walkSpeed = 150.0f;
        [SerializeField, Range(0, 1)] private float _movingThresh = 0.1f;
        [SerializeField, Range(0, 1)] private float _jumpThresh = 0.1f;
        [SerializeField, Range(0, 1)] private float _groundDistance = 0.8f;
        [SerializeField, Range(1, 30)] private float _jumpStartForce = 10.0f;
        [SerializeField, Range(-50, 1)] private float _gravityForce = -10f;
        [SerializeField, Range(1, 20)] private int _animationSpeed = 10;
        [SerializeField, Range(1, 50)] private int _health = 3;
        private SpriteAnimatorConfig _knightAnimeCnf;
        
        [Header("Fire Attack")] 
        public GameObject FireBallPrefab;
        public Transform BarrelPosition;
        [SerializeField, Range(1, 50000)] private float _fireAttackForce = 150.0f;
        [SerializeField, Range(1, 50)] private float _fireBallLifeTime = 3.0f;
        [SerializeField, Range(1, 100)] private int _poolSize = 10;

        [Header("Sword Attack")] 
        public GameObject SwordPrefab;
        
        [Header("Sword Shield")] 
        public GameObject ShieldPrefab;

        public float StartPointX => _startPointX;
        public float WalkSpeed => _walkSpeed;
        public float MovingThresh => _movingThresh;
        public float JumpThresh => _jumpThresh;
        public float GroundDistance => _groundDistance;
        public float JumpStartForce => _jumpStartForce;
        public float GravityForce => _gravityForce;

        public float FireBallLifeTime => _fireBallLifeTime;

        public int AnimationSpeed => _animationSpeed;
        public int Health => _health;
        public int PoolSize => _poolSize;

        public float FireAttackForce => _fireAttackForce;

        public SpriteAnimatorConfig KnightAnimeCnf
        {
            get
            {
                if (_knightAnimeCnf == null)
                {
                    _knightAnimeCnf = Load<SpriteAnimatorConfig>("Anime/" + _knightAnimeCnfPath);
                }

                return _knightAnimeCnf;
            }
        }
    }
}
