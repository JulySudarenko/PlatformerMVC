﻿using System;
using Pathfinding;
using UnityEngine;

namespace Platformer
{
    public class StalkerAI
    {
        private readonly EnemyConfig _config;
        private readonly StalkerAIModel _model;
        private readonly Transform _target;
        private readonly DamagingObjects _damagingObjects;
        private readonly Vector3 _right = new Vector3(-1, 1, 1);
        private readonly Vector3 _left = new Vector3(1, 1, 1);
        private ITimeRemaining _timeRemaining;
        private InitializeCharacter _enemy;
        private SpriteAnimator _animator;
        private Seeker _seeker;
        private Vector2 _newVelocity;


        public StalkerAI(EnemyConfig config, StalkerAIModel model, Transform target, DamagingObjects damagingObjects)
        {
            _damagingObjects = damagingObjects;
            _config = config != null ? config : throw new ArgumentNullException(nameof(config));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
            _target = target != null ? target : throw new ArgumentNullException(nameof(target));
        }

        public void Initialize()
        {
            IFactory enemyFactory = new Factory(_config.EnemySimplePrefab);
            _enemy = new InitializeCharacter(enemyFactory);
            _damagingObjects.AddDamagingObject(_enemy.ID);
            _enemy.Transform.position = _config.WayPoints[0].position;
            _animator = new SpriteAnimator(_config.EnemyAnimatorCnf);
            _animator.StartAnimation(_enemy.SpriteRenderer, AnimState.Run, true, _config.EnemyAnimationSpeed);

            if (_enemy.Transform.TryGetComponent<Seeker>(out var seeker))
                _seeker = seeker;
            
            _timeRemaining = new TimeRemaining(RecalculatePath, 1.0f, true);
            _timeRemaining.AddTimeRemaining();
        }

        public void FixedExecute(float deltaTime)
        {
            _newVelocity = _model.CalculateVelocity(_enemy.Transform.position) * deltaTime;
            _enemy.Rigidbody.velocity = _newVelocity;
            _animator.Execute(deltaTime);
            MakeTurn();
        }

        private void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_enemy.Rigidbody.position, _target.position, OnPathComplete);
            }
        }

        private void OnPathComplete(Path path)
        {
            if (path.error) return;
            _model.UpdatePath(path);
        }
        
        private void MakeTurn()
        {
            _enemy.Transform.localScale = _newVelocity.x > 0 ? _right : _left;
        }

        public void Cleanup()
        {
            _timeRemaining.RemoveTimeRemaining();
        }
    }
}
