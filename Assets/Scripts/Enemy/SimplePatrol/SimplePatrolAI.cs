using System;
using UnityEngine;


namespace Platformer
{
    public class SimplePatrolAI
    {
        private readonly EnemyConfig _config;
        private readonly SimplePatrolAIModel _aiModel;
        private readonly DamagingObjects _damagingObjects;
        private readonly Vector3 _right = new Vector3(-1, 1, 1);
        private readonly Vector3 _left = new Vector3(1, 1, 1);
        private InitializeCharacter _enemy;
        private SpriteAnimator _animator;
        private Vector2 _newVelocity;

        public SimplePatrolAI(EnemyConfig config, SimplePatrolAIModel aiModel, DamagingObjects damagingObjects)
        {
            _damagingObjects = damagingObjects;
            _config = config != null ? config : throw new ArgumentException(nameof(config));
            _aiModel = aiModel != null ? aiModel : throw new ArgumentException(nameof(aiModel));
        }

        public void Initialize()
        {
            IFactory enemyFactory = new Factory(_config.EnemySimplePrefab);
            _enemy = new InitializeCharacter(enemyFactory);
            _damagingObjects.AddDamagingObject(_enemy.ID);
            _enemy.Transform.position = _config.WayPoints[0].position;
            _animator = new SpriteAnimator(_config.EnemyAnimatorCnf);
            _animator.StartAnimation(_enemy.SpriteRenderer, AnimState.Run, true, _config.EnemyAnimationSpeed);
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
    }
}
