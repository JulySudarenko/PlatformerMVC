using UnityEngine;
using static Platformer.Extentions;

namespace Platformer
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public LayerMask Mask;
        [SerializeField] private string _knightAnimeCnfPath = "AnimKnightCnf";
        [SerializeField, Range(-20, 20)] private float _startPointX = -5.0f;
        [SerializeField, Range(1, 20)] private int _animationSpeed = 10;
        [SerializeField, Range(1, 500)] private float _walkSpeed = 150.0f;
        [SerializeField, Range(0, 1)] private float _movingThresh = 0.1f;
        [SerializeField, Range(0, 1)] private float _jumpThresh = 0.1f;
        [SerializeField, Range(0, 1)] private float _groundDistance = 0.8f;
        [SerializeField, Range(1, 30)] private float _jumpStartForce = 10.0f;
        [SerializeField, Range(-50, 1)] private float _gravityForce = -10f;
        private SpriteAnimatorConfig _knightAnimeCnf;

        public float StartPointX => _startPointX;
        public float WalkSpeed => _walkSpeed;
        public float MovingThresh => _movingThresh;
        public float JumpThresh => _jumpThresh;
        public float GroundDistance => _groundDistance;
        public float JumpStartForce => _jumpStartForce;
        public float GravityForce => _gravityForce;
        public int AnimationSpeed => _animationSpeed;
        
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
