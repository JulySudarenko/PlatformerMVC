﻿using UnityEngine;

namespace Platformer
{
    public class MainEntryPoint : MonoBehaviour
    {
        [Header("Configs")]
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        [SerializeField] private UIData _uiData;

        [Header("Traps")]
        [SerializeField] private CannonView _cannon;
        [SerializeField] private GameObject _mace;
        [SerializeField] private GameObject _bridge;
        [SerializeField] private GameObject _saw;
        [SerializeField] private GameObject _lazer;
        [SerializeField] private TriggerContacts _finishPoint;

        [Header("Quest")] 
        [SerializeField] private QuestObjectView _singleQuestView;
        [SerializeField] private QuestStoryConfig[] _questStoryConfigs;
        [SerializeField] private QuestObjectView[] _questObjects;

        private Controllers _controllers;

        private void Awake()
        {
            var damagingPlayerObjects = new DamagingObjects();
            var damagingEnemyObjects = new DamagingObjects();
            var player = new PlayerInitialization(new PlayerFactory(_charactersData.PlayerConfig));
            var cameraController = new CameraController(player.Transform);
            var parallaxController = new ParallaxController(cameraController, _environmentData.BackGroundConfig);
            var inputInitialization = new InputInitialization();
            var playerStateController = new PlayerStateController(player, _charactersData.PlayerConfig,
                inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput(), damagingPlayerObjects.AllDamagingObjects, damagingEnemyObjects);
            var coinController = new CoinPlaceController(parallaxController.CoinsPlaces, _environmentData.CoinCnf,
                cameraController, player.ID);
            var displayInitialization = new DisplayInitialization(_uiData, playerStateController, coinController);
            
            var cannon = new AimingCannonController(_cannon.TurretTransform, player.Transform);
            var coreEmitter = new CoresEmitterController(_cannon.EmitterTransform, _cannon.TurretTransform,
                _environmentData.CannonConfig, damagingPlayerObjects);
            var mace = new MaceController(_mace, damagingPlayerObjects);
            var bridge = new BridgeDivider(_bridge, player.ID);
            damagingPlayerObjects.AddDamagingObject(_saw.GetInstanceID());
            damagingPlayerObjects.AddDamagingObject(_lazer.GetInstanceID());
            
            var questStoryFinisher = new QuestStoryFinisher(_finishPoint);

            _controllers = new Controllers();
            _controllers.Add(cameraController);
            _controllers.Add(parallaxController);
            _controllers.Add(displayInitialization);
            _controllers.Add(new InputController(inputInitialization.GetMoveInput(),
                inputInitialization.GetAttackInput()));
            _controllers.Add(playerStateController);
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(coinController);
            _controllers.Add(new LevelCompleteManager(player.Transform, parallaxController.DeathZones, _finishPoint,
                playerStateController, player.ID));
           
            _controllers.Add(new EnemySimpleController(_charactersData.SnailEnemyCnf, damagingPlayerObjects, damagingEnemyObjects.AllDamagingObjects));
            _controllers.Add(new EnemySimpleController(_charactersData.SlugEnemyCnf, damagingPlayerObjects, damagingEnemyObjects.AllDamagingObjects));
            _controllers.Add(new EnemyStalkerController(_charactersData.BatEnemyCnf, player.Transform, damagingPlayerObjects, damagingEnemyObjects.AllDamagingObjects));
            _controllers.Add(new EnemyProtectorController(_charactersData.EvilBatEnemyCnf, player.Transform, damagingPlayerObjects, damagingEnemyObjects.AllDamagingObjects));

            _controllers.Add(cannon);
            _controllers.Add(coreEmitter);
            _controllers.Add(bridge);
            _controllers.Add(mace);
            _controllers.Add(new QuestsConfigurator(_singleQuestView, _questStoryConfigs, _questObjects, questStoryFinisher,
                player.ID));
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
