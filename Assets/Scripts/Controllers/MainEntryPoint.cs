﻿using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        private Controllers _controllers;

        [SerializeField] private CannonView _cannon;
        [SerializeField] private GameObject _mace;
        [SerializeField] private GameObject _bridge;
        [SerializeField] private TriggerContacts _finishPoint;

        private void Awake()
        {
            var player = new PlayerInitialization(new PlayerFactory(_charactersData.PlayerConfig));
            var cameraController = new CameraController(player.Transform);
            var parallaxController = new ParallaxController(cameraController, _environmentData.BackGroundConfig);
            var inputInitialization = new InputInitialization();
            var playerStateController = new PlayerStateController(player, _charactersData.PlayerConfig,
                inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput());

            var cannon = new AimingCannonController(_cannon.TurretTransform, player.Transform);
            var coreEmitter = new CoresEmitterController(_cannon.EmitterTransform, _cannon.TurretTransform,
                _environmentData.CannonConfig);
            var mace = new MaceController(_mace);
            var bridge = new BridgeDivider(_bridge);

            _controllers = new Controllers();
            _controllers.Add(cameraController);
            _controllers.Add(parallaxController);
            _controllers.Add(new InputController(inputInitialization.GetMoveInput(),
                inputInitialization.GetAttackInput()));
            _controllers.Add(playerStateController);
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(new CoinPlaceController(parallaxController.CoinsPlaces, _environmentData.CoinCnf,
                cameraController));
            _controllers.Add(new LevelCompleteManager(player.Transform, parallaxController.DeathZones, _finishPoint,
                playerStateController));

            _controllers.Add(new EnemySimpleController(_charactersData.SnailEnemyCnf));
            _controllers.Add(new EnemySimpleController(_charactersData.SlugEnemyCnf));
            _controllers.Add(new EnemyStalkerController(_charactersData.BatEnemyCnf, player.Transform));
            _controllers.Add(new EnemyProtectorController(_charactersData.EvilBatEnemyCnf, player.Transform));

            _controllers.Add(cannon);
            _controllers.Add(coreEmitter);
            _controllers.Add(bridge);
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
