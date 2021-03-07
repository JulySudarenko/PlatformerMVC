using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Platformer
{
    public sealed class CorePool
    {
        private Action _reloadingBullet;
        private readonly List<Transform> _cores;
        private readonly CoreInitialization _coreInitialization;
        private readonly CannonConfig _config;
        private readonly Transform _rootPool;
        private readonly int _capacityPool;

        public CorePool(CoreFactory coreFactory, CannonConfig config)
        {
            _coreInitialization = new CoreInitialization(coreFactory);
            _config = config;
            _capacityPool = _config.PoolSize;
            _cores = new List<Transform>();
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.CANNON_CORE_ROOT).transform;
            }
        }

        public Transform GetCore()
        {
            var core = _cores.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (core == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _coreInitialization.CreateCore();
                    ReturnToPool(instantiate.transform);
                    _cores.Add(instantiate.transform);
                }

                GetCore();
            }

            core = _cores.FirstOrDefault(a => !a.gameObject.activeSelf);
            return core;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }
}
