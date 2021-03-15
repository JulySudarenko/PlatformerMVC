using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Platformer
{
    internal class ParalaxBackGround
    {
        private readonly ICamera _camera;
        private readonly BackGroundConfig _config;
        private readonly Transform _back;
        private readonly Vector3 _backStartPosition;
        private readonly Vector3 _cameraStartPosition;
        private Vector3 _cameraNewPosition;
        private Vector3 _cameraDeltaPosition;
        private float _previousBackPosition;

        public ParalaxBackGround(ICamera camera, Transform back, BackGroundConfig config)
        {
            _camera = camera;
            _back = back;
            _config = config;
            _backStartPosition = _back.transform.position;
            _cameraStartPosition = _camera.CameraTransform.position;
            _previousBackPosition = _cameraStartPosition.x;
        }

        public void Execute()
        {
            _cameraNewPosition = _camera.CameraTransform.position;
            _cameraDeltaPosition = _cameraNewPosition - _cameraStartPosition;
            _back.position = _backStartPosition + _cameraDeltaPosition * _config.SpeedCoefficient;

            CheckChildLocation(_cameraNewPosition.x - _previousBackPosition > 0 ? -1 : 1);

            _previousBackPosition = _cameraNewPosition.x;
        }

        private void CheckChildLocation(int sign)
        {
            foreach (Transform child in _back.transform)
            {
                var childPosition = child.transform.position;

                if (sign * childPosition.x > sign * (_cameraNewPosition.x + sign * (_config.Size + _config.Size / 2)))
                {
                    childPosition.x -= sign * _config.Size * _config.SizeCoefficient;
                    child.transform.position = childPosition.Change(x: childPosition.x);
                }
            }
        }

        public List<Transform> GetCoinsPlaces()
        {
            var places = new List<Transform>();
            if (_config.IsCoinPlace)
            {
                places.AddRange(_back.transform.Cast<Transform>());
            }

            return places;
        }
        
        public List<TriggerContacts> GetDeathZones()
        {
            var deathZones = new List<TriggerContacts>();
            if (!_config.IsDeathZone) return deathZones;
            foreach (Transform child in _back.transform)
            {
                deathZones.Add(child.gameObject.GetOrAddComponent<TriggerContacts>());
            }

            return deathZones;
        }
    }
}
