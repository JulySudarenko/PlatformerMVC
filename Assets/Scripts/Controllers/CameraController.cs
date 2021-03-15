using UnityEngine;

namespace Platformer
{
    internal class CameraController : ICamera, IExecute
    {
        private readonly Transform _camera;
        private readonly Transform _player;
        private readonly Vector3 _offsetRight;
        private readonly Vector3 _offsetLeft;
        private readonly float _damping = 1.1f;
        private readonly float _yMin = -0.1f;
        private readonly float _yMax = 5.8f;
        private Vector3 _target;
        private Vector3 _currentPosition;
        private float _clampedY;

        public CameraController(Transform player)
        {
            _camera = Camera.main.transform;
            _player = player;
            _offsetRight = _camera.position - _player.position;
            _offsetLeft = _camera.position + _player.position;
        }

        public Transform CameraTransform => _camera.transform;

        public void Execute(float deltaTime)
        {
            _target = _player.localScale.x > 0 ? _player.position + _offsetRight : _player.position + _offsetLeft;
            _currentPosition = Vector3.Lerp(_camera.position, _target, _damping * deltaTime);
            _clampedY = Mathf.Clamp(_currentPosition.y, _yMin, _yMax);
            _camera.position = _currentPosition.Change(y: _clampedY);
        }
    }
}
