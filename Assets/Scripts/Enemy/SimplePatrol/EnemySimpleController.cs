namespace Platformer
{
    internal class EnemySimpleController : IInitialize, IFixedExecute
    {
        private readonly EnemyConfig _config;
        private readonly DamagingObjects _damagingObjects;
        private SimplePatrolAI _simplePatrolAI;

        public EnemySimpleController(EnemyConfig config, DamagingObjects damagingObjects)
        {
            _config = config;
            _damagingObjects = damagingObjects;
        }

        public void Initialize()
        {
            _simplePatrolAI = new SimplePatrolAI(_config, new SimplePatrolAIModel(_config), _damagingObjects);
            _simplePatrolAI.Initialize();
        }

        public void FixedExecute(float deltaTime)
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedExecute(deltaTime);
        }
    }
}
