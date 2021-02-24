using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private AnimationData _animationData;
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        private Controllers _controllers;

        [SerializeField] private Transform _back;
        [SerializeField] private Transform _middle;
        [SerializeField] private Transform _front;
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
            var camera = Camera.main;
            var redSpotAnimator = new SpriteAnimator(_animationData.RedSpotAnimatorCnf);
            var snailAnimator = new SpriteAnimator(_animationData.SnailAnimatorCnf);
            var coinAnimator = new SpriteAnimator(_animationData.CoinAnimatorCnf);
            var rocketAnimator = new SpriteAnimator(_animationData.RocketAnimatorCnf);
            var batAnimator = new SpriteAnimator(_animationData.BatEnemyAnimatorCnf);
            var evilBatAnimator = new SpriteAnimator(_animationData.EvilBatEnemyAnimatorCnf);

            var paralaxBack = new ParalaxManager(camera.transform, _back,
                _environmentData.BackGroundConfig.SlowSpeedBackGround);
            var paralaxMiddle = new ParalaxManager(camera.transform, _middle,
                _environmentData.BackGroundConfig.FastSpeedBackGround);
            var paralaxFront = new ParalaxManager(camera.transform, _front,
                _environmentData.BackGroundConfig.SpeedForeGround);

            //var paralaxBack = new ParalaxManager(camera.transform,
            //     _environmentData.BackGroundConfig.MountainsBackGroundSlow,
            //     _environmentData.BackGroundConfig.SlowSpeedBackGround);
            // var paralaxMiddle = new ParalaxManager(camera.transform,
            //     _environmentData.BackGroundConfig.MountainsBackGroundFast,
            //     _environmentData.BackGroundConfig.FastSpeedBackGround);
            // var paralaxFront = new ParalaxManager(camera.transform,
            //     _environmentData.BackGroundConfig.MountainsForeGround,
            //     _environmentData.BackGroundConfig.FastSpeedBackGround);

            _controllers = new Controllers();
            _controllers.Add(redSpotAnimator);
            _controllers.Add(snailAnimator);
            _controllers.Add(coinAnimator);
            _controllers.Add(rocketAnimator);
            _controllers.Add(batAnimator);
            _controllers.Add(evilBatAnimator);
            _controllers.Add(paralaxBack);
            _controllers.Add(paralaxMiddle);
            _controllers.Add(paralaxFront);

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
