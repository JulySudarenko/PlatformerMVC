using UnityEngine;

namespace Platformer
{
    internal class ParalaxManager : IExecute
    {
        private Transform _camera;
        private Transform _back;
        private Vector3 _backstartPosition;
        private Vector3 _cameraStartPosition;
        private float _coefBack;

        public ParalaxManager(Transform camera, Transform back, float coef)
        {
            _camera = camera;
            _back = back;
            _coefBack = coef;
            _backstartPosition = _back.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }

        public void Execute(float deltatime)
        {
            _back.position = _backstartPosition + (_camera.position - _cameraStartPosition) * _coefBack;
        }
    }
}
