using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    public class CoresEmitterController : IInitialize
    {
        private readonly List<CoreController> _coreControllers;
        private readonly Pool _corePool;
        private readonly Transform _barrel;
        private readonly Transform _turret;
        private readonly CannonConfig _config;
        private ITimeRemaining _timeRemaining;

        public CoresEmitterController(Transform barrel, Transform turret, CannonConfig config)
        {
            _barrel = barrel;
            _config = config;
            _turret = turret;
            _corePool = new Pool(new Factory(_config.CorePrefab), _config.PoolSize, NameManager.CANNON_CORE_ROOT);
            _coreControllers = new List<CoreController>();
        }

        public void Initialize()
        {
            _timeRemaining = new TimeRemaining(Shoot, _config.SpawnCoreTime, true);
            _timeRemaining.AddTimeRemaining();
        }

        private void Shoot()
        {
            var controlledCore = _coreControllers.FirstOrDefault(a => !a.IsActive);
            if (controlledCore == null)
            {
                controlledCore = new CoreController(_corePool.GetPoolObject(), _config);
                _coreControllers.Add(controlledCore);
            }
            controlledCore.Throw(_barrel.position, -_turret.up * _config.Force);
        }
    }
}
