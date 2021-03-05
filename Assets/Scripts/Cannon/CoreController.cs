using UnityEngine;

namespace Platformer
{
    public class CoreController
    {
        private readonly LayerMask _mask;
        private readonly CoreView _core;
        private readonly Transform _shootDirection;
        private readonly float _radius = 0.08f;
        private readonly float _groundLevel = -3f;
        private readonly float _gravityForce = -10f;
        private Vector3 _velocity;
        private bool _isStartPosition;


        public CoreController(CoreView core, Transform shootDirection)
        {
            _core = core;
            _isStartPosition = true;
            _core.SetVisible(false);
            _shootDirection = shootDirection;
            _mask = LayerMask.GetMask("GameLevel");
        }

        public void Execuite(float deltaTime)
        {
            if (IsGrounded())
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _core.Transform.position = _core.Transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + Vector3.up * (_gravityForce * deltaTime));
                _core.Transform.position += _velocity * deltaTime;
                _core.Transform.rotation = _shootDirection.rotation;
                    if(_isStartPosition) Active(true);
            }
        }
        public void Active(bool value)
        {
            _core.Trail.enabled = value;
            _core.SetVisible(value);
            _core.gameObject.SetActive(value);
            _isStartPosition = false;
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _core.Transform.position = position;
            SetVelocity(velocity);
            _core.SetVisible(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.left, _velocity);
            var axis = Vector3.Cross(Vector3.left, _velocity);
            _core.Transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return Physics2D.Raycast(_core.Transform.position, Vector2.down, _groundLevel, _mask);
            //return _core.Transform.position.y <= _groundLevel + _radius + float.Epsilon && _velocity.y <= 0;
        }
    }
}
