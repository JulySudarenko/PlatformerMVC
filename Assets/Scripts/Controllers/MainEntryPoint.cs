using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private AnimationData _animationData;
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        private Controllers _controllers;

        [SerializeField] private CannonView _cannon;
        [SerializeField] private LevelObjectView _coinView;
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

            var cannon = new AimingCannonController(_cannon.TurretTransform, player.Transform);
            var coreEmitter = new CoresEmitterController(player.Transform, _cannon.EmitterTransform,
                _environmentData.CannonConfig);

            var coinAnimator = new SpriteAnimator(_animationData.CoinAnimatorCnf);
            var batAnimator = new SpriteAnimator(_animationData.BatEnemyAnimatorCnf);
            var evilBatAnimator = new SpriteAnimator(_animationData.EvilBatEnemyAnimatorCnf);

            _controllers = new Controllers();
            _controllers.Add(cameraController);
            _controllers.Add(paralaxController);
            _controllers.Add(new InputController(inputInitialization.GetMoveInput(),
                inputInitialization.GetAttackInput()));
            _controllers.Add(new PlayerStateController(player.Transform, player.SpriteRenderer,
                _charactersData.PlayerConfig,
                inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput()));
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(cannon);
            _controllers.Add(coreEmitter);


            _controllers.Add(coinAnimator);
            _controllers.Add(batAnimator);
            _controllers.Add(evilBatAnimator);

            coinAnimator.StartAnimation(_coinView.SpriteRenderer, _animState, true, _animationSpeed);
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
