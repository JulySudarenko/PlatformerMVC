using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class CoresEmitterController : IInitialize, IExecute
    {
        private readonly List<CoreController> _coreControllers;
        private ITimeRemaining _timeRemaining;
        private readonly CorePool _corePool;
        private readonly Transform _barrel;
        private readonly Transform _turret;
        private readonly CannonConfig _config;

        public CoresEmitterController(Transform barrel, Transform turret, CannonConfig config)
        {
            _barrel = barrel;
            _config = config;
            _turret = turret;
            _corePool = new CorePool(new CoreFactory(_config), _config);
            _coreControllers = new List<CoreController>();
        }

        public void Initialize()
        {
            _timeRemaining = new TimeRemaining(Shoot, _config.SpawnCoreTime, true);
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
            var coreController = _corePool.GetControlledCore();
            _coreControllers.Add(coreController);
            coreController.Throw(_barrel.position, -_turret.up * _config.Force);
        }
    }
}
