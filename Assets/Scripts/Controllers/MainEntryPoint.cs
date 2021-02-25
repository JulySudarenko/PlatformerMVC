using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private AnimationData _animationData;
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        private Controllers _controllers;

        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private LevelObjectView _snailView;
        [SerializeField] private LevelObjectView _coinView;
        [SerializeField] private LevelObjectView _rocketView;
        [SerializeField] private LevelObjectView _batView;
        [SerializeField] private LevelObjectView _evilBatView;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimState _animState;

        private void Awake()
        {
            var camera = new CameraController(_playerView.Transform);
            var paralaxController = new ParalaxController(camera, _environmentData.BackGroundConfig);

            var redSpotAnimator = new SpriteAnimator(_animationData.RedSpotAnimatorCnf);
            var snailAnimator = new SpriteAnimator(_animationData.SnailAnimatorCnf);
            var coinAnimator = new SpriteAnimator(_animationData.CoinAnimatorCnf);
            var rocketAnimator = new SpriteAnimator(_animationData.RocketAnimatorCnf);
            var batAnimator = new SpriteAnimator(_animationData.BatEnemyAnimatorCnf);
            var evilBatAnimator = new SpriteAnimator(_animationData.EvilBatEnemyAnimatorCnf);

            _controllers = new Controllers();
            _controllers.Add(redSpotAnimator);
            _controllers.Add(snailAnimator);
            _controllers.Add(coinAnimator);
            _controllers.Add(rocketAnimator);
            _controllers.Add(batAnimator);
            _controllers.Add(evilBatAnimator);
            _controllers.Add(paralaxController);

            redSpotAnimator.StartAnimation(_playerView.SpriteRenderer, _animState, true, _animationSpeed);
            snailAnimator.StartAnimation(_snailView.SpriteRenderer, _animState, true, _animationSpeed);
            coinAnimator.StartAnimation(_coinView.SpriteRenderer, _animState, true, _animationSpeed);
            rocketAnimator.StartAnimation(_rocketView.SpriteRenderer, _animState, true, _animationSpeed);
            batAnimator.StartAnimation(_batView.SpriteRenderer, AnimState.Attack, true, _animationSpeed);
            evilBatAnimator.StartAnimation(_evilBatView.SpriteRenderer, AnimState.Attack, true, _animationSpeed);
        }

        private void Start()
        {
            _controllers.Initialize();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
