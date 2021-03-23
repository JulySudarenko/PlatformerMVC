using System;
using UnityEngine;


namespace Platformer
{
    public class SimplePatrolAI
    {
        private readonly LevelObjectView _view;
        private readonly SimplePatrolAIModel _aiModel;
        private readonly SpriteAnimator _animator;
        private LayerMask _layerMask;
        private float _distance = 2.0f;
        private RaycastHit2D _hit;
        private readonly Vector3 _right = new Vector3(-1, 1, 1);
        private readonly Vector3 _left = new Vector3(1, 1, 1);
        private Vector2 _newVelocity;
        private float _animationSpeed = 10.0f;
        private float _viewUp = 1.3f;

        public SimplePatrolAI(LevelObjectView view, SimplePatrolAIModel aiModel, SpriteAnimatorConfig animator, LayerMask layerMask)
        {
            _layerMask = layerMask;
            _view = view != null ? view : throw new ArgumentException(nameof(view));
            _aiModel = aiModel != null ? aiModel : throw new ArgumentException(nameof(aiModel));
            _animator = animator != null ? new SpriteAnimator(animator) : throw new ArgumentException(nameof(animator));
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
