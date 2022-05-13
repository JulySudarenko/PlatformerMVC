using System.Collections.Generic;

namespace Platformer
{
    internal class EnemySimpleController : IInitialize, IFixedExecute, ICleanup
    {
        private List<int> _killingObjects;
        private readonly EnemyConfig _config;
        private readonly DamagingObjects _damagingObjects;
        private SimplePatrolAI _simplePatrolAI;

        public EnemySimpleController(EnemyConfig config, DamagingObjects damagingObjects, List<int> killingObjects)
        {
            _config = config;
            _damagingObjects = damagingObjects;
            _killingObjects = killingObjects;
        }

        public void Initialize()
        {
            _simplePatrolAI = new SimplePatrolAI(_config, new SimplePatrolAIModel(_config), _damagingObjects,
                _killingObjects);
            _simplePatrolAI.Initialize();
        }

        public void FixedExecute(float deltaTime)
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedExecute(deltaTime);
        }

        public void Cleanup()
        {
            _simplePatrolAI.Cleanup();
        }
    }
}
