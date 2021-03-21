using System;
using UnityEngine;

namespace Platformer
{
    public class SimplePatrolAI
    {
        private readonly LevelObjectView _view;
        private readonly SimplePatrolAIModel _aiModel;
        private readonly SpriteAnimator _animator;
        private readonly Vector3 _right = new Vector3(-1, 1, 1);
        private readonly Vector3 _left = new Vector3(1, 1, 1);
        private Vector2 _newVelocity;
        private float _animationSpeed = 10.0f;

        public SimplePatrolAI(LevelObjectView view, SimplePatrolAIModel aiModel, SpriteAnimatorConfig animator)
        {
            _view = view != null ? view : throw new ArgumentException(nameof(view));
            _aiModel = aiModel != null ? aiModel : throw new ArgumentException(nameof(aiModel));
            _animator = animator != null ? new SpriteAnimator(animator) : throw new ArgumentException(nameof(animator));
            _animator.StartAnimation(_view.SpriteRenderer, AnimState.Run, true, _animationSpeed);
        }

        public void FixedExecute(float deltaTime)
        {
            _newVelocity = _aiModel.CalculateVelocity(_view.transform.position) * deltaTime;
            _view.Rigidbody2D.velocity = _newVelocity;
            MakeTurn();
            _animator.Execute(deltaTime);
        }

        private void MakeTurn()
        {
            _view.Transform.localScale = _newVelocity.x > 0 ? _right : _left;
        }
    }
}
