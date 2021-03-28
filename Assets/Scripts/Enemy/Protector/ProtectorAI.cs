using System;
using Pathfinding;
using UnityEngine;

namespace Platformer
{
    internal class ProtectorAI : IProtector
    {
        private EnemyConfig _config;
        private Transform _target;
        private PatrolAIModel _model;
        private InitializeCharacter _enemy;
        private SpriteAnimator _animator;
        private AIDestinationSetter _destinationSetter;
        private AIPatrolPath _patrolPath;

        private bool _isPatrolling;

        public ProtectorAI(EnemyConfig config, PatrolAIModel model, Transform target)
        {
            _config = config;
            _target = target;
            _model = model != null ? model : throw new ArgumentException(nameof(model));
        }

        public void Initialize()
        {
            IFactory enemyFactory = new Factory(_config.EnemySimplePrefab);
            _enemy = new InitializeCharacter(enemyFactory);
            _enemy.Transform.position = _config.WayPoints[0].position;
            _animator = new SpriteAnimator(_config.EnemyAnimatorCnf);
            _animator.StartAnimation(_enemy.SpriteRenderer, AnimState.Run, true, _config.EnemyAnimationSpeed);

            if (_enemy.Transform.TryGetComponent<AIDestinationSetter>(out var setter))
            {
                _destinationSetter = setter;
                _destinationSetter.target = _target;
            }

            if (_enemy.Transform.TryGetComponent<AIPatrolPath>(out var path))
                _patrolPath = path;
        }

        public void FixedExecute(float deltaTime)
        {
            _animator.Execute(deltaTime);
        }
        
        public void Init()
        {
            _destinationSetter.target = _model.GetNextTarget();
            _isPatrolling = true;
            _patrolPath.TargetReached += OnTargetReached;
        }

        public void Deinit()
        {
            _patrolPath.TargetReached -= OnTargetReached;
        }

        private void OnTargetReached(object sender, EventArgs e)
        {
            _destinationSetter.target = _isPatrolling 
                ? _model.GetNextTarget() 
                : _model.GetClosestTarget(_enemy.Transform.position);
        }

        public void StartProtection(GameObject invader)
        {
            _isPatrolling = false;
            _destinationSetter.target = invader.transform;
        }

        public void FinishProtection(GameObject invader)
        {
            _isPatrolling = true;
            _destinationSetter.target = _model.GetClosestTarget(_enemy.Transform.position);
        }
    }
}
