using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    internal class EnemyStalkerController : IInitialize, IFixedExecute, ICleanup
    { 
        private readonly List<int> _killingObjects;
        private readonly EnemyConfig _config;
        private readonly Transform _stalkerAITarget;
        private readonly DamagingObjects _damagingObjects;
        private StalkerAI _stalkerAI;
        
        public EnemyStalkerController(EnemyConfig config, Transform target, DamagingObjects damagingObjects, List<int> killingObjects)
        {
            _config = config;
            _stalkerAITarget = target;
            _damagingObjects = damagingObjects;
            _killingObjects = killingObjects;
        }
        
        public void Initialize()
        {
            _stalkerAI = new StalkerAI(_config, new StalkerAIModel(_config), _stalkerAITarget, _damagingObjects, _killingObjects);
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
