using UnityEngine;

namespace Platformer
{
    internal class EnemyStalkerController : IInitialize, IFixedExecute, ICleanup
    { 
        private readonly EnemyConfig _config;
        private readonly Transform _stalkerAITarget;
        private StalkerAI _stalkerAI;
        
        public EnemyStalkerController(EnemyConfig config, Transform target)
        {
            _config = config;
            _stalkerAITarget = target;
        }
        
        public void Initialize()
        {
            _stalkerAI = new StalkerAI(_config, new StalkerAIModel(_config), _stalkerAITarget);
            _stalkerAI.Initialize();
        }

        public void FixedExecute(float deltaTime)
        {
            if (_stalkerAI != null) _stalkerAI.FixedExecute(deltaTime);
        }

        public void Cleanup()
        {
            _stalkerAI.Cleanup();
        }
    }
}
