using System;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Platformer
{
    internal class EnemyProtectorController : IInitialize, IFixedExecute, ICleanup
    {
        private Transform _protectorAITarget;

        private EnemyConfig _config;
        private AIDestinationSetter _protectorAIDestinationSetter;
        private AIPatrolPath _protectorAIPatrolPath;
        private LevelObjectTrigger _protectedZoneTrigger;
        
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;

        public EnemyProtectorController(EnemyConfig config, Transform target)
        {

            _config = config != null ? config : throw new ArgumentException(nameof(config));
            _protectorAITarget = target!= null ? target : throw new ArgumentException(nameof(target));
        }

        public void Initialize()
        {
            _protectorAI = new ProtectorAI(_config, new PatrolAIModel(_config.WayPoints.ToArray()), _protectorAITarget); 
            _protectorAI.Initialize();
            _protectorAI.Init();

            var zone = Object.Instantiate(_config.ProtectedZone);
            
            _protectedZone = new ProtectedZone(zone, new List<IProtector> {_protectorAI});
            _protectedZone.Init();
        }

        public void Cleanup()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
        }

        public void FixedExecute(float deltaTime)
        {
            _protectorAI.FixedExecute(deltaTime);
        }
    }
}
