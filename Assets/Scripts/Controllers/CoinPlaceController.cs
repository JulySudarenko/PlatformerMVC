using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    internal class CoinPlaceController : IExecute, IInitialize, ICleanup
    {
        private readonly List<Transform> _originalplaces;
        private readonly List<Vector3> _allPlaces;
        private readonly List<CoinController> _coinControllers;
        private readonly Pool _coinsPool;
        private readonly ICamera _camera;
        private readonly ItemConfig _config;
        private readonly float _controlStep = 20.0f;
        private readonly float _startLevelPoint = -5f;
        private readonly float _finishLevelPoint = 100;
        private readonly int _countOnPlatform;
        private readonly int _contactID;
        private float _controlPoint;

        public CoinPlaceController(List<Transform> platforms, ItemConfig coinConfig, ICamera camera, int contactID)
        {
            _originalplaces = platforms;
            _coinsPool = new Pool(new Factory(coinConfig.ItemPrefab), coinConfig.ItemPoolSize, NameManager.COIN_ROOT);
            _allPlaces = new List<Vector3>();
            _coinControllers = new List<CoinController>();
            _countOnPlatform = coinConfig.ItemCount;
            _config = coinConfig;
            _camera = camera;
            _contactID = contactID;
            _controlPoint = _camera.CameraTransform.position.x + _controlStep;
        }

        public void Initialize()
        {
            foreach (var platform in _originalplaces)
            {
                if (platform.position.x > _startLevelPoint)
                    CreateCoinsOnPlatform(platform.position);
            }
        }

        public void Execute(float deltaTime)
        {
            if (_camera.CameraTransform.position.x >= _controlPoint)
            {
                _controlPoint += _controlStep;
                CheckNewPlatformPosition();
            }

            foreach (var controller in _coinControllers)
            {
                controller.Execute(deltaTime);
            }
        }

        private void CreateCoinsOnPlatform(Vector3 position)
        {
            _allPlaces.Add(position);
            var deltaY = 1;
            for (int i = 0; i < _countOnPlatform; i++)
            {
                var coinController = _coinControllers.FirstOrDefault(a => !a.IsActive);
                if (coinController == null)
                {
                    coinController = new CoinController(_coinsPool.GetPoolObject(), _config, _contactID);
                    _coinControllers.Add(coinController);
                }

                coinController.Activate(true, position, deltaY++);
            }
        }

        private void CheckNewPlatformPosition()
        {
            for (var index = 0; index < _originalplaces.Count; index++)
            {
                if (_originalplaces[index].position.x < _finishLevelPoint)
                {
                    bool flag = true;
                    for (var i = 0; i < _allPlaces.Count; i++)
                    {
                        if (_originalplaces[index].position == _allPlaces[i])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        _allPlaces.Add(_originalplaces[index].position);
                        CreateCoinsOnPlatform(_originalplaces[index].position);
                    }
                }
            }
        }

        public void Cleanup()
        {
            foreach (var controller in _coinControllers)
            {
                controller.Cleanup();
            }
        }
    }
}
