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
        [SerializeField] private Vector3 _startPointX = new Vector3(-5.0f, 0.0f, 0.0f);
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private float _walkSpeed = 3.0f;
        [SerializeField] private float _movingThresh = 0.1f;
        [SerializeField] private float _groundDistance = 0.8f;
        [SerializeField] private float _jumpStartForce = 8f;
        [SerializeField] private float _gravityForce = -10f;
        private SpriteAnimatorConfig _knightAnimeCnf;

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

        public Vector3 StartPointX => _startPointX;

        public float WalkSpeed => _walkSpeed;

        public float MovingThresh => _movingThresh;

        public float GroundDistance => _groundDistance;

        public float JumpStartForce => _jumpStartForce;

        public float GravityForce => _gravityForce;

        public int AnimationSpeed => _animationSpeed;
    }
}
