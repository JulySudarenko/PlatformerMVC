using UnityEngine;

namespace Platformer
{
    internal class ParalaxManager : IExecute
    {
        private readonly ICamera _camera;
        private readonly BackGroundConfig _config;
        private readonly Transform _back;
        private readonly Vector3 _backStartPosition;
        private readonly Vector3 _cameraStartPosition;
        private float _previousBackPosition;

        public ParalaxManager(ICamera camera, Transform back, BackGroundConfig config)
        {
            _camera = camera;
            _back = back;
            _config = config;
            _backStartPosition = _back.transform.position;
            _cameraStartPosition = _camera.CameraTransform.position;
            _previousBackPosition = _cameraStartPosition.x;
        }

        public void Execute(float deltatime)
        {
            var cameraNewPosition = _camera.CameraTransform.position;
            _back.position = _backStartPosition + (cameraNewPosition - _cameraStartPosition) * _config.SpeedCoefficient;

            if (cameraNewPosition.x - _previousBackPosition > 0)
            {
                foreach (Transform child in _back.transform)
                {
                    var childPosition = child.transform.position;
                    if (childPosition.x < cameraNewPosition.x - _config.Size - _config.Size/2)
                    {
                        childPosition.x += _config.Size * _config.SizeCoefficient;
                        child.transform.position = new Vector3(childPosition.x, childPosition.y, childPosition.z);
                    }
                }
            }

            else if (cameraNewPosition.x - _previousBackPosition < 0)
            {
                foreach (Transform child in _back.transform)
                {
                    var childPosition = child.transform.position;
                    if (childPosition.x > cameraNewPosition.x + _config.Size + _config.Size/2)
                    {
                        childPosition.x -= _config.Size * _config.SizeCoefficient;
                        child.transform.position = new Vector3(childPosition.x, childPosition.y, childPosition.z);
                    }
                }
            }

            _previousBackPosition = cameraNewPosition.x;
        }
    }
}
