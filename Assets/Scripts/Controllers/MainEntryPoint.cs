using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private AnimationData _animationData;
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        private Controllers _controllers;

        [SerializeField] private Transform _cannon;
        [SerializeField] private LevelObjectView _redSpotView;
        [SerializeField] private LevelObjectView _coinView;
        [SerializeField] private LevelObjectView _rocketView;
        [SerializeField] private LevelObjectView _batView;
        [SerializeField] private LevelObjectView _evilBatView;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private AnimState _animState;

        private void Awake()
        {
            var player = new PlayerInitialization(new PlayerFactory(_charactersData.PlayerConfig));
            var cameraController = new CameraController(player.Transform);
            var paralaxController = new ParalaxController(cameraController, _environmentData.BackGroundConfig);
            var inputInitialization = new InputInitialization();
            
            var cannon = new AimingCannon(_cannon, player.Transform);
            
            var redSpotAnimator = new SpriteAnimator(_animationData.RedSpotAnimatorCnf);
            var coinAnimator = new SpriteAnimator(_animationData.CoinAnimatorCnf);
            var rocketAnimator = new SpriteAnimator(_animationData.RocketAnimatorCnf);
            var batAnimator = new SpriteAnimator(_animationData.BatEnemyAnimatorCnf);
            var evilBatAnimator = new SpriteAnimator(_animationData.EvilBatEnemyAnimatorCnf);

            _controllers = new Controllers();
            _controllers.Add(cameraController);
            _controllers.Add(paralaxController);
            _controllers.Add(new InputController(inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput()));
            _controllers.Add(new PlayerStateController(player.Transform, player.SpriteRenderer, _charactersData.PlayerConfig, 
                inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput()));
  
            _controllers.Add(cannon);
            
            _controllers.Add(redSpotAnimator);
            _controllers.Add(coinAnimator);
            _controllers.Add(rocketAnimator);
            _controllers.Add(batAnimator);
            _controllers.Add(evilBatAnimator);
  
            redSpotAnimator.StartAnimation(_redSpotView.SpriteRenderer, _animState, true, _animationSpeed);
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
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
