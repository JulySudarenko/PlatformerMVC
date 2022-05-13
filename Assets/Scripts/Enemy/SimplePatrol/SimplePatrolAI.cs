using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class SimplePatrolAI
    {
        private readonly List<int> _killingObjects;
        private readonly EnemyConfig _config;
        private readonly SimplePatrolAIModel _aiModel;
        private readonly DamagingObjects _damagingObjects;
        private readonly Vector3 _right = new Vector3(-1, 1, 1);
        private readonly Vector3 _left = new Vector3(1, 1, 1);
        private ITimeRemaining _timeRemaining;
        private Hit _hit;
        private InitializeCharacter _enemy;
        private SpriteAnimator _animator;
        private Vector2 _newVelocity;

        public SimplePatrolAI(EnemyConfig config, SimplePatrolAIModel aiModel, DamagingObjects damagingObjects,
            List<int> killingObjects)
        {
            _damagingObjects = damagingObjects;
            _config = config != null ? config : throw new ArgumentException(nameof(config));
            _aiModel = aiModel != null ? aiModel : throw new ArgumentException(nameof(aiModel));
            _killingObjects = killingObjects;
        }

        public void Initialize()
        {
            IFactory enemyFactory = new Factory(_config.EnemySimplePrefab);
            _enemy = new InitializeCharacter(enemyFactory);
            _damagingObjects.AddDamagingObject(_enemy.ID);
            _enemy.Transform.position = _config.WayPoints[0].position;
            _animator = new SpriteAnimator(_config.EnemyAnimatorCnf);
            _animator.StartAnimation(_enemy.SpriteRenderer, AnimState.Run, true, _config.EnemyAnimationSpeed);
            _hit = _enemy.HitInfo;
            _hit.IsContact += IsDead;
        }

        public void FixedExecute(float deltaTime)
        {
            _newVelocity = _aiModel.CalculateVelocity(_enemy.Transform.position) * deltaTime;
            _enemy.Rigidbody.velocity = _newVelocity;
            _animator.Execute(deltaTime);
            MakeTurn();
        }

        private void MakeTurn()
        {
            _enemy.Transform.localScale = _newVelocity.x > 0 ? _right : _left;
        }

        private void IsDead(int contactID)
        {
            foreach (var killer in _killingObjects)
            {
                if (contactID == killer)
                {
                    _animator.StartAnimation(_enemy.SpriteRenderer, AnimState.Death, false,
                        _config.EnemyAnimationSpeed);
                    _timeRemaining = new TimeRemaining(Deactivate, 1.5f, false);
                    _timeRemaining.AddTimeRemaining();
                }
            }
        }

        private void Deactivate()
        {
            _enemy.Transform.gameObject.SetActive(false);
            _timeRemaining.RemoveTimeRemaining();
        }

        public void Cleanup()
        {
            _timeRemaining.RemoveTimeRemaining();
        }
    }
}
