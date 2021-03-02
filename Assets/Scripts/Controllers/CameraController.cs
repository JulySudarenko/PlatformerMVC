using UnityEngine;

namespace Platformer
{
    internal class CameraController : ICamera
    {
        private Camera _camera;
        private Transform _player;
        private Transform _sky;
        private Vector3 _position;

        public CameraController(Transform player)
        {
            _camera = Camera.main;
            _player = player;
        }

        public Transform CameraTransform => _camera.transform;
    }
}
