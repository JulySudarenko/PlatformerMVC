using UnityEngine;


namespace Platformer
{
    public class SimplePatrolAIModel
    {
        private readonly EnemyConfig _config;
        private Transform _target;
        private readonly float _minSgrDistanceToTarget;
        private int _currentPointIndex;

        public SimplePatrolAIModel(EnemyConfig config)
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
            return _config.EnemySpeed * direction;
        }

        private Transform GetNextWayPoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.WayPoints.Count;
            return _config.WayPoints[_currentPointIndex];
        }
    }
}
