using UnityEngine;

namespace Platformer
{
    public class ShotPoint
    {
        private Transform _parentPlayer;
        private Transform _shotPointPosition;

        public ShotPoint(Transform parent, Transform shotPoint)
        {
            _parentPlayer = parent;
            _shotPointPosition = shotPoint;
        }

        public Transform GetShotPoint()
        {
            var barrel = Object.Instantiate(_shotPointPosition, _parentPlayer);
            return barrel.transform;
        }
    }
}
