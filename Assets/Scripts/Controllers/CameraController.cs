using UnityEngine;

namespace Platformer
{
    internal class CameraController : ICamera, IExecute
    {
        private Transform _camera;
        private Transform _player;
        private Vector3 _target;
        private Vector3 _offseRight;
        private Vector3 _offseLeft;
        private Vector3 _currentPosition;
        private float _clampedY;
        private float _damping = 1.1f;
        private float _yMin = -0.1f;
        private float _yMax = 5.8f;

        public CameraController(Transform player)
        {
            _camera = Camera.main.transform;
            _player = player;
            _offseRight = _camera.position - _player.position;
            _offseLeft = _camera.position + _player.position;
        }

        public Transform CameraTransform => _camera.transform;

        public void Execute(float deltaTime)
        {
            _target = _player.localScale.x > 0 ? _player.position + _offseRight : _player.position + _offseLeft;
            _currentPosition = Vector3.Lerp(_camera.position, _target, _damping * deltaTime);
            _clampedY = Mathf.Clamp(_currentPosition.y, _yMin, _yMax);
            _camera.position = _currentPosition.Change(y: _clampedY);
        }
    }
}
