using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    internal class Pool
    {
        private readonly List<Transform> _pool;
        private readonly InitializeItem _initializeItem;
        private readonly Transform _rootPool;
        private readonly int _capacityPool;

        public Pool(IFactory factory, int poolSize, string poolName )
        {
            _initializeItem = new InitializeItem(factory);
            _capacityPool = poolSize;
            _pool = new List<Transform>();
            if (!_rootPool)
            {
                _rootPool = new GameObject(poolName).transform;
            }
        }

        public Transform GetPoolObject()
        {
            var poolObject = _pool.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (poolObject == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = _initializeItem.Create();
                    ReturnToPool(instantiate.transform);
                    _pool.Add(instantiate.transform);
                }

                GetPoolObject();
            }

            poolObject = _pool.FirstOrDefault(a => !a.gameObject.activeSelf);
            return poolObject;
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
