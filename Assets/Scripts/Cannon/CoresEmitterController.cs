using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoresEmitterController : IInitialize, IExecute
    {
        private CorePool _corePool;
        private ITimeRemaining _timeRemaining;
        private Transform _target;
        private Transform _barrel;
        private CannonConfig _config;
        
        private const float _delay = 2.0f;
        private const float _startSpeed = 9.0f;

        private List<CoreController> _cores = new List<CoreController>();
        private Transform _transform;
        private int _currentIndex;
        private float _timeTillNext;

        public CoresEmitterController(Transform target, Transform barrel, CannonConfig config)
        {
            _transform = target;
            _barrel = barrel;
            _config = config;
            _corePool = new CorePool(new CoreFactory(_config), _config.PoolSize);
        }

        public void Initialize()
        {
            _timeRemaining = new TimeRemaining(Shoot, _delay, true);
            _timeRemaining.AddTimeRemaining();
        }
        
        public void Execute(float deltaTime)
        {
        }

        private void Shoot()
        {
            var core = _corePool.GetCore();
            core.gameObject.AddTransform(_barrel);
            core.gameObject.SetActive(true);
        }
    }
}
