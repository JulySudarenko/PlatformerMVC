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
        private Transform _turret;
        private CannonConfig _config;
        private CoreController _coreController;
        private List<CoreController> _coreControllers;

        private const float _delay = 2.0f;

        // private int _currentIndex;
        private float _timeTillNext;

        public CoresEmitterController(Transform target, Transform barrel, Transform turret, CannonConfig config)
        {
            _target = target;
            _barrel = barrel;
            _config = config;
            _turret = turret;
            _corePool = new CorePool(new CoreFactory(_config), _config.PoolSize);
            _coreControllers = new List<CoreController>();
        }

        public void Initialize()
        {
            _timeRemaining = new TimeRemaining(Shoot, _delay, true);
            _timeRemaining.AddTimeRemaining();
        }

        public void Execute(float deltaTime)
        {
            foreach (var coreController in _coreControllers)
            {
                coreController.Execuite(deltaTime);
            }
        }

        private void Shoot()
        {
            var core = _corePool.GetCore();
            //core.gameObject.AddTransform(_barrel);
            core.gameObject.SetActive(true);
            var coreController = new CoreController(core, _turret, _config);
            _coreControllers.Add(coreController);
            coreController.Throw(_barrel.position, -_turret.up * _config.Force);
        }
    }
}
