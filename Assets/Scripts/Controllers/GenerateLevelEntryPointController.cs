using UnityEngine;
using Level;

namespace Platformer
{
    internal class GenerateLevelEntryPointController : MonoBehaviour
    {
        [SerializeField] private GenerateLevelView _levelView;
        [SerializeField] private CharactersData _charactersData;
        [SerializeField] private EnvironmentData _environmentData;
        [SerializeField] private TriggerContacts _finishPoint;
        private Controllers _controllers;

        private GeneratorLevelController _levelGenerator;

        private void Awake()
        {
            var damagingObjects = new DamagingObjects();
            var player = new PlayerInitialization(new PlayerFactory(_charactersData.PlayerConfig));
            var cameraController = new CameraController(player.Transform);
            var inputInitialization = new InputInitialization();
            var playerStateController = new PlayerStateController(player, _charactersData.PlayerConfig,
                inputInitialization.GetMoveInput(), inputInitialization.GetAttackInput(), damagingObjects.AllDamagingObjects);
            
            _levelGenerator = new GeneratorLevelController(_environmentData.LevelConfig, player.Transform.position);

            _controllers = new Controllers();
            _controllers.Add(_levelGenerator);
            _controllers.Add(cameraController);
            _controllers.Add(new InputController(inputInitialization.GetMoveInput(),
                inputInitialization.GetAttackInput()));
            _controllers.Add(playerStateController);
            _controllers.Add(new TimeRemainingController());
            _controllers.Add(new LevelCompleteManager(player.Transform, _levelGenerator.AddDeathZone(), _finishPoint,
                playerStateController, player.ID));
            
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
