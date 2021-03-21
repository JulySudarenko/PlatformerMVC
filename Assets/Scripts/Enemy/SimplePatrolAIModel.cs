using UnityEngine;

namespace Platformer
{
    public class SimplePatrolAIModel
    {
        private readonly AIConfig _config;
        private Transform _target;
        private readonly float _minSgrDistanceToTarget;
        private int _currentPointIndex;

        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWayPoint();
            _minSgrDistanceToTarget = _config.MINDistanceToTarget * _config.MINDistanceToTarget;
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2) _target.position - fromPosition);
            if (sqrDistance <= _minSgrDistanceToTarget)
            {
                _target = GetNextWayPoint();
            }

            var direction = ((Vector2) _target.position - fromPosition).normalized;
            return _config.Speed * direction;
        }

        private Transform GetNextWayPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.Waypoints.Length;
            return _config.Waypoints[_currentPointIndex];
        }
    }
}
