using System.Collections.Generic;
using System.Linq;
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
            var controlledCore = _coreControllers.FirstOrDefault(a => !a.IsActive);
            if (controlledCore == null)
            {
                controlledCore = new CoreController(_corePool.GetCore(), _config);
                _coreControllers.Add(controlledCore);
            }
            controlledCore.Throw(_barrel.position, -_turret.up * _config.Force);
        }
    }
}
